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

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(20)]
        [InlineData(-1)]
        public void DetectLocationsTest(int totalLoc)
        {
            int totalLocations = totalLoc;
            if (totalLoc < 2)
            {
                totalLocations = rgn.Next(2, 11);
            }
            
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

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(20)]
        [InlineData(-1)]
        public void ReturnDijkstraRouteTest(int totalLoc)
        {
            int totalLocations = totalLoc;
            if (totalLoc < 2)
            {
                totalLocations = rgn.Next(2, 11);
            }

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
        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(20)]
        [InlineData(-1)]
        public void ReturnShortestDijkstraRouteTest(int totalLoc)
        {
            int totalLocations = totalLoc;
            if (totalLoc < 2)
            {
                totalLocations = rgn.Next(2, 11);
            }

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
        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(20)]
        [InlineData(-1)]
        public void UnreachableLocationTest(int totalLoc)
        {
            int totalLocations = totalLoc;
            if (totalLoc < 4)
            {
                totalLocations = rgn.Next(2, 11);
            }

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
