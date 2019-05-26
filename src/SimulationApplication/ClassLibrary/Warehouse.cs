using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
	public class Warehouse : Building
	{
        [NotMapped]
		private List<Vehicle> vehicles;
        [NotMapped]
        private List<Shop> shops;
        [NotMapped]
        private int totalvehiclesAtStart;
        [NotMapped]
        public List<Road> Roads { get; }
        [NotMapped]
        public List<Vehicle> Vehicles { get {return vehicles; } }
        [NotMapped]
        public int TotalVehiclesAtStart { get { return totalvehiclesAtStart; } set { if (value >= 1) { totalvehiclesAtStart = value; } else { throw new Exception("Total Vehicles per Warehouse should be greater than 0"); } } }
        [NotMapped]
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

        public void RemoveAllvehicles()
        {
            foreach(Vehicle v in vehicles)
            {
                v.picBox.Dispose();
            }
            vehicles.Clear();
        }

        public Warehouse(PictureBox PicBox)
            :base(PicBox)
        {
            //Roads = new List<Road>();
            TotalVehiclesAtStart = 1;
            vehicles = new List<Vehicle>();
        }

        public Warehouse(PictureBox PicBox, int totalVehicles)
            : base(PicBox)
        {
            //Roads = new List<Road>();
            if(totalVehicles < 1) { throw new Exception("Total Vehicles per Warehouse should be greater than 0"); }
            this.totalvehiclesAtStart = totalVehicles;
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle v)
        {
            vehicles.Add(v);
        }

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
        /// Returns the vehicle (and time) that can accepts a new delivery the fastest
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="time"></param>
        public void fastestVehicleAvailableTime(out Vehicle vehicle, out int time)
        {
            time = int.MaxValue;
            vehicle = null;
            foreach (Vehicle v in vehicles)
            {
                int returnTime = v.lastDeliveryFinishDeltaTime(); //Get the time it takes to start delivering a new Delivery
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
        public void NextTick(int timeStamp)
        {
            foreach(Vehicle v in vehicles)
            {
                v.NextTick(timeStamp);
            }          
        }
        public StatisticsWarehouse MakeStatistics(int timeStamp)
        {
            List<StatisticsVehicle> vehiclesStat = new List<StatisticsVehicle>();
            foreach(Vehicle v in vehicles)
            {
                vehiclesStat.Add(v.MakeStatistics(timeStamp));
            }
            StatisticsWarehouse temp = new StatisticsWarehouse(timeStamp, this, vehiclesStat);
            return temp;
        }
    }
}
