using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary.Events;


namespace ClassLibrary
{
	public class Warehouse : Building
	{
		private List<Vehicle> vehicles;
		private List<Shop> shops;

        public List<Road> Roads { get; }

        public List<Shop> Shops
        {
            get
            {
                return new List<Shop>(shops);
            }
            set
            {
                shops = value;
                foreach (Shop shop in this.shops)
                {
                    shop.LowStockReached += Item_LowStockReached;
                }
            }
        }
        
        public Warehouse(PictureBox PicBox)
            :base(PicBox)
        {
            Roads = new List<Road>();
        }
        public Warehouse() { }

        /// <summary>
        /// Event that triggers when a shop needs to restock 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_LowStockReached(object sender, LowStockReachedEventArgs e)
        {
            // Logic to get a vehicle to simulate traveling to the shop
            Console.WriteLine("Time in need of restocking: " + e.TimeReached);
            Shop s = (Shop)sender;
            s.Stock = s.Capacity;
        }


        /// <summary>
        /// Returns the shop that has the ID equal to the given ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Shop GetShop(int ID)
        {
            return shops.Find(shop => shop.ID == ID);
        }
    }
}
