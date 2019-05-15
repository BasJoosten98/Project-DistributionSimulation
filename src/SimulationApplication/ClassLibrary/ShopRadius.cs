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
        private int demandEffect;

        public Shop Shop { get { return this.shop; } }
        public ShopRadius(Shop s, int Demand)
        {
            shop = s;
            demandEffect = Demand;
        }

        public int BuyFromShop(int availableDemand)
        {
            if(demandEffect < availableDemand) { availableDemand = demandEffect; }
            int sold = shop.Sell(availableDemand);
            return sold;
        }
    }
}
