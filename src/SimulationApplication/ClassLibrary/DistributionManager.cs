using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class DistributionManager
	{
        private Dijkstra myDijkstra;
        private List<Delivery> createdDeliveries;
        private List<Delivery> finishedCreatedDeliveries;
        private List<Location> warehouses;
        private List<Location> shops;

        public List<Delivery>  CreatedDeliveries { get; set; }

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

        private void createDelivery(DijkstraRoute Route, Vehicle vehicle, Location warehouseLoc)
        {
            Delivery temp = new Delivery(Route, warehouseLoc);
            createdDeliveries.Add(temp);
            vehicle.AddDeliveryToQueue(temp);
        }
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
            //order
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
        private void forseeDeliveries()
        {
            List<Location> lowStockShops = getShopsWithLowStockOrdered();
            checkDeliveriesIsFinished();

            //filter out shops that have already been helped
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

            //check foreach warehouse which can deliver the fastest
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
                createDelivery(bestRoute, bestVehicle, bestWarehouse);
                Console.WriteLine("New delivery for SHOP" + s.LocationID + " Stock: " + ((Shop)s.Building).Stock);
            }
        }
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

        public void nextTick()
        {
            forseeDeliveries();
        }
    }
}
