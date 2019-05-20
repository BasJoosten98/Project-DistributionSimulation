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
        private StatisticsShop previous;

        public Shop Shop { get { return shop; } }
        public int Stock { get { return stock; } }
        public int Sold { get { return sold; } }
        public int TotalZeroStockTime { get { return calculateZeroStockTime(); } } //Total amount of time units where Stock == 0
        public double AverageStock { get { return calculateAverageStock(); } }
        public double AverageSold { get { return calculateAverageSold(); } }

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

        private int calculateZeroStockTime()
        {
            int sum = 0;
            if(previous != null)
            {
                sum += previous.calculateZeroStockTime();
            }
            if(stock == 0) { sum++; }
            return sum;
        }
        private double calculateAverageStock()
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
        private double calculateAverageSold()
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
