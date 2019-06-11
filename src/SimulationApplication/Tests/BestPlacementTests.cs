using Xunit;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    public class BestPlacementTests
    {
        private Map map = new Map(10, 10, 10);
        private List<Building> _buildings;
        public List<int> bestMap;
        private int _ticks;
        private double _maxSold = 0;
        List<int> mapBuild = new List<int>();

        [Fact()]
        public void BestPlacementTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void MakeBackupsTest()
        {
            Location location1 = new Location(1, 1, 1);
            location1.Building = new Shop(10, 10);
            Location location2 = new Location(2, 2, 2);
            location2.Building = new Warehouse(20);
            map.AddNewBuilding(location1);
            map.AddNewBuilding(location2);
            List<Location> Buildings = new List<Location>();

            foreach (Location item in map.Shops)
            {
                Buildings.Add(item);
            }
            foreach (Location item2 in map.Warehouses)
            {
                Buildings.Add(item2);
            }

            Assert.Equal(Buildings, map.Shops.Concat(map.Warehouses));
        }

        [Fact()]
        public void CheckBestPlacementTest()
        {
            Location location1 = new Location(1, 1, 1);
            location1.Building = new Shop(10, 10);
            Location location2 = new Location(2, 2, 2);
            location2.Building = new Warehouse(20);
            map.AddNewBuilding(location1);
            map.AddNewBuilding(location2);
            mapBuild.Add(0);
            mapBuild.Add(1);

            List<Location> Buildings = new List<Location>();

            _buildings = new List<Building>();
            foreach (Location item in map.Shops)
            {
                _buildings.Add(item.Building);
            }
            foreach (Location item2 in map.Warehouses)
            {
                _buildings.Add(item2.Building);
            }

            foreach (Location item in map.Shops)
            {
                Buildings.Add(item);
            }
            foreach (Location item2 in map.Warehouses)
            {
                Buildings.Add(item2);
            }

            for (int i = 0; i < mapBuild.Count; i++)
            {
                if (mapBuild[i] != -1)
                {
                    map.Locations[i].Building = _buildings[mapBuild[i]];
                    map.AddNewBuilding(map.Locations[i]);
                }
            }
            map.PrepareForSimulation();
            foreach (Location l in map.Warehouses)
            {
                Warehouse w = (Warehouse)l.Building;

                for (int i = 1; i <= w.TotalVehiclesAtStart; i++)
                {
                    Vehicle temp = new Vehicle(new System.Windows.Forms.PictureBox());
                    w.AddVehicle(temp);
                }
            }
            for (int i = 0; i <= _ticks; i++)
            {
                map.NextTick(i);
            }
            double sum = 0;
            foreach (Statistics item in map.Statistics)
            {
                if (item.Time == _ticks)
                {
                    if (item is StatisticsShop)
                    {
                        StatisticsShop obj = (StatisticsShop)item;
                        sum += obj.AverageSold;
                    }
                }
            }
            if (sum > _maxSold)
            {
                _maxSold = sum;
                bestMap = mapBuild;
            }
            map.ResetMap();
            Assert.Equal(_maxSold, sum);
            Assert.Equal(bestMap, mapBuild);
        }

        [Fact()]
        public void CheckCombinationsTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetBestBuildTest()
        {
            Location location1 = new Location(1, 1, 1);
            location1.Building = new Shop(10, 10);
            Location location2 = new Location(2, 2, 2);
            location2.Building = new Warehouse(20);
            map.AddNewBuilding(location1);
            map.AddNewBuilding(location2);
            BestPlacement b = new BestPlacement(map,50,null);
            b.MakeBackups();
            b.CheckBestPlacement(new List<int>() { 0, 1});
            List<int> best = b.GetBestBuild(); 
            Assert.NotNull(best);
        }

        [Fact()]
        public void GetBuildingsTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void createAllDifferentMapsTest()
        {
            int totalBuidings = 2;
            int totalLocations = 10;
            Console.WriteLine("Start of difmaps");
            if (totalBuidings > totalLocations) { throw new Exception("Not possible"); }
            List<int> temp = new List<int>();
            for (int i = 1; i <= totalLocations; i++)
            {
                temp.Add(-1);
            }

            BestPlacement b = new BestPlacement(map, 50, null);
            List<List<int>> result = b.createAllDifferentMapsRec(totalBuidings - 1, 0, temp);

            if (true)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    string holder = "";
                    for (int j = 0; j < result[i].Count; j++)
                    {
                        holder += " " + result[i][j];
                    }
                    Console.WriteLine(holder);
                }
            }
            Console.WriteLine("End of difmaps");
            Assert.NotNull(result);
        }

    } 
}