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
        private StatisticsShop tempStat = null; //needed for statistics
        private int restockAmount;
        private int stock;

        public static int id;
        public int Capacity { get; set; }
		public int Stock { get { return this.stock; } set { if (value >= 0) { this.stock = value; } else { throw new Exception("Stock must be greater than or equal to 0"); } } }
        public int RestockAmount { get { return this.restockAmount; }set { if (value >= 0) { this.restockAmount = value; } else { throw new Exception("Restock must be greater than or equal to 0"); } } }
        public int ID { get; set; }


        public event EventHandler<LowStockReachedEventArgs> LowStockReached;

        public Shop(PictureBox PicBox, int StockAmount, int Restock)
            :base(PicBox)
        {
            if (Restock < 0) { throw new Exception("Restock must be greater than or equal to 0"); }
            if (StockAmount < 0) { throw new Exception("Stock must be greater than or equal to 0"); }
            stock = StockAmount;
            restockAmount = Restock;
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
            

        public StatisticsShop MakeStatistics(int timeStamp)
        {
            StatisticsShop temp = new StatisticsShop(timeStamp, this, Stock, tempSold, tempStat);
            tempSold = 0;
            tempStat = temp;
            return temp;
        }
        
	}
}
