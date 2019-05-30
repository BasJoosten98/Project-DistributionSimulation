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
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void CheckCombinationsTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetBestBuildTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetBuildingsTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}