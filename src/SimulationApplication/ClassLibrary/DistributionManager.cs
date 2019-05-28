using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class DistributionManager
	{
        private Dijkstra myDijkstra; //dijkstra object for calculating shortest route
        private List<Delivery> createdDeliveries; //list of deliveries that are active (handling)
        private List<Delivery> finishedCreatedDeliveries; //list of deliveries that are finished (vehicle is back at the warehouse)
        private List<Location> warehouses; //all locations that contain warehouse
        private List<Location> shops; //all locations that contain shop

        public Dijkstra DistDijkstra { get { return myDijkstra; } }

        public DistributionManager(Dijkstra dijkstra, List<Location> Warehouses, List<Location> Shops)
        {
            myDijkstra = dijkstra;
            warehouses = Warehouses;
            createdDeliveries = new List<Delivery>();
            finishedCreatedDeliveries = new List<Delivery>();
            shops = Shops;
            if (shops.Count == 0) { throw new NullReferenceException(); }
            if (warehouses.Count == 0) { throw new NullReferenceException(); }
        }

        /// <summary>
        /// Create delivery for Vehicle located at warehouseLoc and where it should follow Route
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Vehicle"></param>
        /// <param name="WarehouseLoc"></param>
        private void createDelivery(DijkstraRoute Route, Vehicle Vehicle, Location WarehouseLoc, int timeStamp)
        {
            Delivery temp = new Delivery(Route, WarehouseLoc, timeStamp);
            createdDeliveries.Add(temp);
            Vehicle.AddDeliveryToQueue(temp);
        }
        /// <summary>
        /// Go through all given shops and return a list of shops ordered by stock (from low to high)
        /// </summary>
        /// <returns></returns>
        private List<Location> getShopsWithLowStockOrdered()
        {
            List<Location> lowStockShops = new List<Location>();
            List<Location> lowStockShopsOrdered = new List<Location>();

            //get all shops that need restock
            foreach(Location l in shops)
            {
                if(((Shop)l.Building).Stock <= ((Shop)l.Building).RestockAmount)
                {
                    lowStockShops.Add(l);
                }
            }
            //order based on stock
            for(int i = 0; i < lowStockShops.Count; i++)
            {
                for(int j = 0; j < lowStockShops.Count; j++)
                {
                    if(((Shop)lowStockShops[i].Building).Stock < ((Shop)lowStockShops[j].Building).Stock)
                    {
                        i = j;
                    }
                }
                lowStockShopsOrdered.Add(lowStockShops[i]);
                lowStockShops.RemoveAt(i);
                i = -1;
            }
            return lowStockShopsOrdered;
        }
        /// <summary>
        /// Provide deliveries to shops
        /// </summary>
        private void forseeDeliveries(int timeStamp)
        {
            List<Location> lowStockShops = getShopsWithLowStockOrdered();
            checkDeliveriesIsFinished();

            //filter out shops that have an active delivery
            for(int i = 0; i < lowStockShops.Count; i++)
            {
                foreach(Delivery d in createdDeliveries)
                {
                    if(d.Route.EndPoint == lowStockShops[i])
                    {
                        lowStockShops.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }

            //Create the fastest deliveries for each shop by looking at available vehicles and the traveltime from warehouse to shop
            foreach(Location s in lowStockShops)
            {
                int outTime;
                Vehicle outVehicle;
                DijkstraRoute tempRoute;
                ((Warehouse)warehouses[0].Building).fastestVehicleAvailableTime(out outVehicle, out outTime);

                DijkstraRoute bestRoute = myDijkstra.GetRouteTo(warehouses[0], s);
                int totalTimeSpan = bestRoute.RouteLenght + outTime;
                Vehicle bestVehicle = outVehicle;
                Location bestWarehouse = warehouses[0];
                for(int i = 1; i < warehouses.Count; i++)
                {
                    ((Warehouse)warehouses[i].Building).fastestVehicleAvailableTime(out outVehicle, out outTime);
                    tempRoute = myDijkstra.GetRouteTo(warehouses[i], s);
                    if(tempRoute.RouteLenght + outTime < totalTimeSpan)
                    {
                        bestRoute = tempRoute;
                        totalTimeSpan = tempRoute.RouteLenght + outTime;
                        bestVehicle = outVehicle;
                        bestWarehouse = warehouses[i];
                    }
                }
                createDelivery(bestRoute, bestVehicle, bestWarehouse, timeStamp);
                //Console.WriteLine("New delivery for SHOP" + s.LocationID + " Stock: " + ((Shop)s.Building).Stock);
            }
        }

        /// <summary>
        /// Go through all active deliveries and see which ones are finished, move them to the finished delivery list
        /// </summary>
        private void checkDeliveriesIsFinished()
        {
            for(int i = 0; i < createdDeliveries.Count; i++)
            {
                if(createdDeliveries[i].Status == DeliveryStatus.COMINGBACK)
                {
                    finishedCreatedDeliveries.Add(createdDeliveries[i]);
                    createdDeliveries.RemoveAt(i);
                    i--;
                }
            }
        }

        public void NextTick(int timeStamp)
        {
            forseeDeliveries(timeStamp);
        }
    }
}
