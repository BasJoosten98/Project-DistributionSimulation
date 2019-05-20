using Xunit;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    public class WarehouseTests
    {
        [Fact()]
        public void WarehouseTest()
        {
            List<Shop> shops = new List<Shop>() { new Shop(10, 5) };
            Warehouse warehouse = new Warehouse(shops);
            Assert.NotNull(warehouse);
        }

        [Fact()]
        public void CheckSubscriptionTest()
        {
            List<Shop> shops = new List<Shop>() { new Shop(10, 5) };
            Warehouse warehouse = new Warehouse(shops);
        }

        [Fact()]
        public void GetShopTest()
        {
            List<Shop> shops = new List<Shop>() { new Shop(10, 5) };

            Warehouse warehouse = new Warehouse(shops);

            Shop s = shops.Find(shop => shop.ID == 1);
            Assert.NotNull(s);
        }
    }
}