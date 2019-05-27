using Xunit;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SimulationApplication
{
    public class DistributionManagerTests
    {

        private Random rgn = new Random();
        [Fact()]
        public void CalculateOrderShops()
        {
            
            int totalLocations = 10;
            List<Location> locations = new List<Location>();
            List<Road> roads = new List<Road>();
            List<Location> shops = new List<Location>();
            List<Location> warehouses = new List<Location>();


            //create a random amount of locations
            //for (int i = 0; i < totalLocations; i++)
            //{
            //    Location temp = new Location(rgn.Next(0, 100), rgn.Next(0, 100));
            //    locations.Add(temp);
            //}
            Location temp = new Location(0, 100);
            locations.Add(temp);
            Location temp2 = new Location(10, 90);
            locations.Add(temp2);
            Location temp3 = new Location(20, 80);
            locations.Add(temp3);
            Location temp4 = new Location(34, 70);
            locations.Add(temp4);
            Location temp5 = new Location(47, 60);
            locations.Add(temp5);
            Location temp6 = new Location(55, 50);
            locations.Add(temp6);
            Location temp7 = new Location(63, 40);
            locations.Add(temp7);
            //create a random amount of roads
            foreach (Location l1 in locations)
            {
                foreach (Location l2 in locations)
                {
                    if (l1 != l2)
                    {
                        Road tempi = new Road(l1, l2);
                        roads.Add(tempi);
                    }
                }
            }

            foreach (var l in locations)
            {
                int id = l.LocationID;
                PictureBox picBox = new PictureBox();
                PictureBox picBox1 = new PictureBox();
                Point ImagePosition = new Point((l.Index.Column * Cell.CellSize) + 4, (l.Index.Row * Cell.CellSize) + 4);
                picBox.Location = ImagePosition;
                picBox.Size = new Size(Cell.CellSize - 1, Cell.CellSize - 1);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (l == temp && l == temp4 && l == temp7)
                {
                    l.Building = new Shop(19, 20);
                    l.Building.picBox = picBox;
                    shops.Add(l);

                    //lbLocationLog.Text = "Location #: " + id + " has been set to a Shop";
                    //  Console.WriteLine("Location #: " + id + " has been set to a Shop");
                }
                if (l == temp6)
                {
                    l.Building = new Warehouse(picBox);

                    
                    Vehicle vehicle = new Vehicle(picBox1);
                    Vehicle vehicle2 = new Vehicle(picBox1);

                    ((Warehouse)l.Building).AddVehicle(vehicle);
                    ((Warehouse)l.Building).AddVehicle(vehicle2);
                    warehouses.Add(l);

                }
              

            }
            //List<Location> myWarehouses = new List<Location>();
            //foreach (var l in warehouses)
            //{
            //    myWarehouses.add
            //}
            Dijkstra d = new Dijkstra(roads);
            DistributionManager dm = new DistributionManager(d,warehouses,shops);

            dm.nextTick();
 
            Assert.Equal(3,dm.CreatedDeliveries.Count);
        }
    }
}