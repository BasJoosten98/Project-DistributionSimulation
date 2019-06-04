using Xunit;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    public class ShopTests
    {
        /// <summary>
        /// These tests define the core functionality of the shop class, raising events for the listeners (warehouses)
        /// and getting the expected result (on eventraise, shop stock should be back to the capacity)
        /// </summary>



        [Fact()]
        public void OnLowStockReachedTest()
        {
            List<Shop> shops = new List<Shop>() { new Shop(10, 5) };

            Warehouse warehouse = new Warehouse(shops);

            //The first shop in the warehouse will have ID 1
            Shop s = warehouse.GetShop(1);
            s.Sell(6);
            //The event gets triggered and the restock is back to the capacity it can carry
            Assert.True(s.Stock == s.Capacity);

        }

        [Fact()]
        public void SellTest()
        {
            Shop s = new Shop(10, 5);
            s.Sell(3);
            Assert.True(s.Stock == 7);
        }
    }
}