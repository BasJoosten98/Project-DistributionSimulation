using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ShopRadius
    {
        private Shop shop; 
        private int demandPercentage;

        public Shop Shop { get { return this.shop; } }
        public ShopRadius(Shop s, int Demand)
        {
            shop = s;
            demandPercentage = Demand;
        }

        /// <summary>
        /// Cell buys products from shop based on availableDemand of the cell
        /// </summary>
        /// <param name="availableDemand"></param>
        /// <returns></returns>
        public int BuyFromShop(int availableDemand)
        {
            int totalDemand = (int)Math.Floor((double)availableDemand * demandPercentage / 100);
            int sold = shop.Sell(totalDemand);
            return sold;
        }
    }
}
