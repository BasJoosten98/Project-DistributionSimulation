using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StatisticsShop : Statistics
    {
        private Shop shop;
        private int stock;
        private int sold;
        private StatisticsShop previous; // what does this represent?

        public Shop Shop { get { return shop; } }
        public int Stock { get { return stock; } }
        public int Sold { get { return sold; } }
        public int TotalZeroStockTime { get { return calculateZeroStockTime(); } } //Total amount of time units where Stock == 0
        public double AverageStock { get { return calculateAverageStock(); } } // display the AverageStock ? what does that mean?
        public double AverageSold { get { return calculateAverageSold(); } } // Average sold stock I suppose.

        public StatisticsShop(int timeStamp, Shop me, int stock, int sold, StatisticsShop prev)
            :base(timeStamp)
        {
            shop = me;
            this.stock = stock;
            this.sold = sold;
            previous = prev;
            if (prev != null && false) //testing
            {
                Console.WriteLine("current id: " + ID + " previous id: " + previous.ID);
                Console.WriteLine("Stock: " + stock + " Sold: " + sold);
                Console.WriteLine("TZST: " + TotalZeroStockTime + " AStock: " + AverageStock + " ASold: " + AverageSold);
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        /// <summary>
        /// Returns the value of time units that the shops had 0 stock
        /// </summary>
        /// <returns></returns>
        public int calculateZeroStockTime()
        {
            int sum = 0;
            if(previous != null)
            {
                sum += previous.calculateZeroStockTime();
            }
            if(stock == 0) { sum++; }
            return sum;
        }

        //
        public double calculateAverageStock()
        {
            double sum = 0;
            if (previous != null)
            {
                sum += previous.calculateAverageStock();
                sum += stock;
                return sum /= 2;
            }           
            return Stock;
        }
        public double calculateAverageSold()
        {
            double sum = 0;
            if (previous != null)
            {
                sum += previous.calculateAverageSold();
                sum += sold;
                return sum /= 2;
            }
            return sold;
        }

    }
}
