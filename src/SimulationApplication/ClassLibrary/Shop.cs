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
        public static int id;
        public int Capacity { get; set; }
		public int Stock { get; set; }
        public int RestockAmount { get; set; }
        public int ID { get; set; }

        public event EventHandler<LowStockReachedEventArgs> LowStockReached;

        public Shop(PictureBox PicBox, int stock, int restockamount) : base(PicBox)
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

        public void nextTick(int demand)
        {
            Sell(demand);
        }
        
	}
}
