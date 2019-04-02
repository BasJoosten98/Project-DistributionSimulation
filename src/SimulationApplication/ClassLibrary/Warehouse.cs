using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Events;


namespace ClassLibrary
{
	public class Warehouse : Building
	{
		private List<Vehicle> vehicles;
		private List<Shop> queue;



        public Warehouse(List<Shop> shops): base()
        {
            queue = shops;
            foreach (Shop item in queue)
            {
                item.LowStockReached += Item_LowStockReached;
            }
        }

        private void Item_LowStockReached(object sender, LowStockReachedEventArgs e)
        {
            // Logic to get a vehicle to simulate traveling to the shop
            Console.WriteLine("Time in need of restocking: " + e.TimeReached);
            Shop s = (Shop)sender;
            s.Stock = s.Capacity;
        }

        public Shop GetShop(int ID)
        {
            return queue.Find(x => x.ID == ID);
        }
    }
}
