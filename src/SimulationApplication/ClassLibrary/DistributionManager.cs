using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class DistributionManager
	{
        private Dijkstra myDijkstra;
        private List<Delivery> createdDeliveries;
       // private List<Location> locations;
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

        private void createDelivery(List<Road> Route, Vehicle vehicle)
        {
            Delivery temp = new Delivery(Route);
            createdDeliveries.Add(temp);
            vehicle.AddDeliveryToQueue(temp);
        }

    }
}
