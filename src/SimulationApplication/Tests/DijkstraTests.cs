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
        public void DetectLocationsTest()
        {
            int totalLocations = rgn.Next(2, 11);
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
            Dijkstra d = new Dijkstra(roads);

            Assert.True(d.totalDetectedLocations == totalLocations);
        }
        [Fact()]
        public void ReturnDijkstraRouteTest()
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
        [Fact()]
        public void ReturnShortestDijkstraRouteTest()
        {
            int totalLocations = rgn.Next(4, 11);
            List<Location> locations = new List<Location>();
            List<Road> roads = new List<Road>();
            for (int i = 0; i < totalLocations; i++)
            {
                Location temp = new Location(rgn.Next(0, 100), rgn.Next(0, 100));
                locations.Add(temp);
            }
            for (int i = 0; i < locations.Count - 1; i++)
            {
                Road temp = new Road(locations[i], locations[i + 1]);
                temp.initialCost = rgn.Next(1, 4);
                roads.Add(temp);
            }
            int randomRoadsCount = (int)Math.Floor((double)totalLocations / 2);
            for (int i = 1; i <= randomRoadsCount; i++)
            {
                int num1 = rgn.Next(0, randomRoadsCount);
                int num2 = rgn.Next(randomRoadsCount, totalLocations);
                Road temp = new Road(locations[num1], locations[num2]);
                temp.initialCost = rgn.Next(50, 100);
                roads.Add(temp);
            }
            Dijkstra d = new Dijkstra(roads);
            DijkstraRoute dr = d.GetRouteTo(locations[0], locations[totalLocations - 1]);
            Assert.True(dr.RouteLenght < 50);
        }
        [Fact()]
        public void UnreachableLocationTest()
        {
            int totalLocations = rgn.Next(4, 11);
            List<Location> locations = new List<Location>();
            List<Road> roads = new List<Road>();
            for (int i = 0; i < totalLocations; i++)
            {
                Location temp = new Location(rgn.Next(0, 100), rgn.Next(0, 100));
                locations.Add(temp);
            }
            Road r = new Road(locations[0], locations[1]);
            roads.Add(r);
            for(int i = 2; i < totalLocations; i++)
            {
                for (int j = 2; j < totalLocations; j++)
                {
                    if(i != j)
                    {
                        Road temp = new Road(locations[i], locations[j]);
                        roads.Add(temp);
                    }
                }
            }
            Location from = locations[rgn.Next(2, totalLocations)];
            Location to = locations[rgn.Next(0, 2)];
            Dijkstra d = new Dijkstra(roads);
            DijkstraRoute dr = d.GetRouteTo(from, to);
            Assert.True(dr == null);
        }

    }
}
