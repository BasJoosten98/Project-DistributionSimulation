using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Xunit;

namespace SimulationApplicationTests
{
    public class DijkstraTests
    {
        private Random rgn = new Random();
        [Fact()]
        public void DetectLocationTest()
        {
            int totalLocations = rgn.Next(2, 11);
            List<Location> locations = new List<Location>();
            List<Road> roads = new List<Road>();
            for(int i = 0; i < totalLocations; i++)
            {
                Location temp = new Location(rgn.Next(0, 100), rgn.Next(0, 100));
                locations.Add(temp);
            }
            foreach(Location l1 in locations)
            {
                foreach(Location l2 in locations)
                {
                    if (l1 != l2)
                    {
                        Road temp = new Road(l1, l2);
                        roads.Add(temp);
                    }
                }
            }
            Dijkstra d = new Dijkstra(roads);

            Assert.True(d.totalDetectedLocations == totalLocations);
        }
        [Fact()]
        public void ReturnDijkstraRoute()
        {
            int totalLocations = rgn.Next(3, 11);
            List<Location> locations = new List<Location>();
            List<Road> roads = new List<Road>();
            for (int i = 0; i < totalLocations; i++)
            {
                Location temp = new Location(rgn.Next(0, 100), rgn.Next(0, 100));
                locations.Add(temp);
            }
            foreach (Location l1 in locations)
            {
                foreach (Location l2 in locations)
                {
                    if (l1 != l2)
                    {
                        Road temp = new Road(l1, l2);
                        roads.Add(temp);
                    }
                }
            }
            int split = totalLocations / 2;
            Dijkstra d = new Dijkstra(roads);
            DijkstraRoute dr = d.GetRouteTo(locations[rgn.Next(0, split)], locations[rgn.Next(split, totalLocations - 1)]);
            Assert.True(dr != null);
        }
    }
}
