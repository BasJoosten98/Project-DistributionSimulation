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
		private List<Shop> _shops;
        private int totalvehiclesAtStart;

        public List<Road> Roads { get; }
        public List<Vehicle> Vehicles { get {return vehicles; } }
        public int TotalVehiclesAtStart { get { return totalvehiclesAtStart; } set { if (value >= 1) { totalvehiclesAtStart = value; } else { throw new Exception("Total Vehicles per Warehouse should be greater than 0"); } } }

        public List<Shop> Shops
        {
            get
            {
                return new List<Shop>(_shops);
            }
            set
            {
                _shops = value;
                foreach (Shop shop in this._shops)
                {
                    shop.LowStockReached += Item_LowStockReached;
                }
            }
        }
        public void ResetWarehouse()
        {
            Vehicle.ResetId();
            RemoveAllvehicles();
        }
        public void RemoveAllvehicles()
        {
            if (vehicles != null)
            {
                foreach (Vehicle v in vehicles)
                {
                    v.picBox.Dispose();
                }
                vehicles.Clear();
            }
        }

        public Warehouse() : base()
        {
            TotalVehiclesAtStart = 1;
            vehicles = new List<Vehicle>();
        }
        public Warehouse(List<Shop> shops) : base()
        {
            Shops = shops;
        }

        public Warehouse(PictureBox PicBox) : this()
        {
            picBox = PicBox;
        }
        public Warehouse(PictureBox PicBox, int totalVehicles)
            : base(PicBox)
        {
            //Roads = new List<Road>();
            if(totalVehicles < 1) { throw new Exception("Total Vehicles per Warehouse should be greater than 0"); }
            this.totalvehiclesAtStart = totalVehicles;
            vehicles = new List<Vehicle>();
        }
        public Warehouse(int totalVehicles)
        {
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
            return Shops.Find(shop => shop.ID == ID);
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

        public override void Save(int mapId, int rowIndex, int columnIndex)
        {
            string sql = "INSERT INTO BUILDINGS (MapId, RowIndex, ColumnIndex)" +
                        $"VALUES ('{mapId}', '{rowIndex}', '{columnIndex}');";
            DataBase.ExecuteNonQuery(sql);
        }
    }
}
