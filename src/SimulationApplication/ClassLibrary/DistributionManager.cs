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

        public Dijkstra DistDijkstra { get { return myDijkstra; } }

        public DistributionManager(Dijkstra dijkstra, List<Location> Warehouses, List<Location> Shops)
        {
            myDijkstra = dijkstra;
            warehouses = Warehouses;
            createdDeliveries = new List<Delivery>();
            shops = Shops;
            if (shops.Count == 0) { throw new NullReferenceException(); }
            if (warehouses.Count == 0) { throw new NullReferenceException(); }
        }

        private void createDelivery(DijkstraRoute Route, Vehicle vehicle)
        {
            Delivery temp = new Delivery(Route);
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
                bool wasSmallest = true;
                for(int j = 0; j < lowStockShops.Count; j++)
                {
                    if(i != j)
                    {
                        if(((Shop)lowStockShops[j].Building).Stock < ((Shop)lowStockShops[i].Building).Stock) //lower stock found
                        {
                            i = j;
                            wasSmallest = false;
                        }
                    }
                }
                lowStockShopsOrdered.Add(lowStockShops[i]);
                lowStockShops.RemoveAt(i);
                if (!wasSmallest)
                {
                    i = -1;
                }
            }
            return lowStockShopsOrdered;
        }
        private void sendDeliveries()
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
                        break;
                    }
                }
            }

            //check foreach warehouse which can deliver the fastest
            foreach(Location s in lowStockShops)
            {

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

    }
}
