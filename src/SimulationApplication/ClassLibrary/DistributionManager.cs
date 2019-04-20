using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class DistributionManager
	{
        private Dijkstra myDijkstra;
       // private List<Location> locations;
        private List<Location> warehouses;
        private List<Location> shops;

        public DistributionManager(Dijkstra dijkstra, List<Location> Warehouses, List<Location> Shops)
        {
            myDijkstra = dijkstra;
            warehouses = Warehouses;
            shops = Shops;
            if (shops.Count == 0) { throw new NullReferenceException(); }
            if (warehouses.Count == 0) { throw new NullReferenceException(); }
        }

    }
}
