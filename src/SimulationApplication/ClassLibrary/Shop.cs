using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary.Events;

namespace ClassLibrary
{
	public class Shop : Building
	{
        private int tempSold = 0; //needed for statistics
        private StatisticsShop tempStat; //needed for statistics

        public static int id;
        public int Capacity { get; set; }
		public int Stock { get; set; }
        public int RestockAmount { get; set; }
        public int ID { get; set; }


        public event EventHandler<LowStockReachedEventArgs> LowStockReached;

        public Shop(PictureBox PicBox, int stock, int restockamount)
        {
            Stock = stock;
            Capacity = stock;
            RestockAmount = restockamount;
            ID = ++id;
        }

        //public Shop (int stock, int restockamount)
        //{
        //    Stock = stock;
        //    Capacity = stock;
        //    RestockAmount = restockamount;
            ID = ++id;
        }


        /// <summary>
        /// Event that triggers when the stock is low
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnLowStockReached(LowStockReachedEventArgs e)
        {
            LowStockReached?.Invoke(this, e);
        }

		public int Sell(int demand)
		{
            if(demand > Stock)
        /// <param name="demand"></param>
            {
                demand = Stock;
            }
            Stock -= demand;
            tempSold += demand;
            if (Stock <= RestockAmount)
            {
                LowStockReachedEventArgs args = new LowStockReachedEventArgs();
                args.TimeReached = DateTime.Now;
                OnLowStockReached(args);
            }         
            return demand; //AMOUNT THAT HAS BEEN SOLD
		}        
            
		}

        public StatisticsShop MakeStatistics(int timeStamp)
        {
            StatisticsShop temp = new StatisticsShop(timeStamp, this, Stock, tempSold, tempStat);
            tempSold = 0;
            tempStat = temp;
            return temp;
        }
        
	}
}
