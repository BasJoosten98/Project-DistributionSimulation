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
        public List<Vehicle> Vehicles { get {return vehicles; } }

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
            //Roads = new List<Road>();
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle v)
        {
            vehicles.Add(v);
        }

        private void Item_LowStockReached(object sender, LowStockReachedEventArgs e)
        {
            // Logic to get a vehicle to simulate traveling to the shop
            Console.WriteLine("Time in need of restocking: " + e.TimeReached);
            Shop s = (Shop)sender;
            s.Stock = s.Capacity;
        }

        public void fastestVehicleAvailableTime(out Vehicle vehicle, out int time)
        {
            time = int.MaxValue;
            vehicle = null;
            foreach (Vehicle v in vehicles)
            {
                int returnTime = v.lastDeliveryFinishDeltaTime();
                if(time > returnTime)
                {
                    time = returnTime;
                    vehicle = v;
                }               
            }
        }

        public Shop GetShop(int ID)
        {
            return shops.Find(shop => shop.ID == ID);
        }
        public void NextTick()
        {
            foreach(Vehicle v in vehicles)
            {
                v.NextTick();
            }          
        }
    }
}
