using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Events;

namespace ClassLibrary
{
	public class Shop : Building
	{
        public static int id;
        public int Capacity { get; set; }
		public int Stock { get; set; }
        public int RestockAmount { get; set; }
        public int ID { get; set; }

        public event EventHandler<LowStockReachedEventArgs> LowStockReached;

        public Shop(int stock, int restockamount)
        {
            Stock = stock;
            Capacity = stock;
            RestockAmount = restockamount;
            ID = ++id;
        }

        public virtual void OnLowStockReached(LowStockReachedEventArgs e)
        {
            LowStockReached?.Invoke(this, e);
        }

		public void Sell(int demand)
		{
            Stock -= demand;
            if (Stock <= RestockAmount)
            {
                LowStockReachedEventArgs args = new LowStockReachedEventArgs();
                args.TimeReached = DateTime.Now;
                OnLowStockReached(args);
            }

            
		}

        public Shop() : base()
        {

        }

        
	}
}
