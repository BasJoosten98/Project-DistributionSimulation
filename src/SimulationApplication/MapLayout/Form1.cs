using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
namespace MapLayout
{
    public partial class Form1 : Form
    {
        private SimulationContext context;

        private List<Location> selectedLocations = new List<Location>();
        private Map map;
        //Quick dirty way of checking if the shop or warehouse button is clicked
        private bool isShopBtnClicked;
        private bool isWarehouseBtnClicked;

        //List<Rectangle> ListofRectangles;
        //redraw image method
        //Bitmap bmp;


        public Form1()
        {
            InitializeComponent();

            // This could be set later on, maybe even via the app config file or by the user.
            const int CELLSIZE = 40;

            // The result represents the number of cells we can create in both width and height (Square grid/map) based on the cell size.
            int numberOfCells;
            if (mapPictureBox.Width <= mapPictureBox.Height) { numberOfCells = mapPictureBox.Width / CELLSIZE; }
            else { numberOfCells = mapPictureBox.Height / CELLSIZE; }
            map = new Map(numberOfLocations: 10, numberOfCells: numberOfCells, cellSize: CELLSIZE, MapBox: mapPictureBox);

            // This loop is for debugging purposes such that we can check which cells have a location added to them.
            foreach (Cell cell in map.GetCells())
            {
                if (cell is Location)
                {
                    Console.WriteLine($"Row: {cell.Index.Row}, Col: {cell.Index.Column}");
                }
            }
        }


        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            //change to Graphics.FromImage(bmp) for redraw 
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);

            foreach (Cell c in map.GetCells())
            {
                if (drawHeatMap)
                {
                    sb.Color = c.GetHeatMapCellColor();
                    g.FillRectangle(sb, c.CellRectangle);
                }
                else
                {
                    sb.Color = SystemColors.ActiveCaption;
                    g.FillRectangle(sb, c.CellRectangle);
                }
            }

            foreach (Road r in map.Edges)
            {
                //Draw Line
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                p.Color = r.LineColor;
                p.Width = r.LineWidth;
                g.DrawLine(p, r.Location1.Center, r.Location2.Center);

                //Draw String
                sb.Color = r.StringColor;
                Font f = new Font("Arial", 13, FontStyle.Bold);
                g.DrawString(r.InitialCost.ToString(), f, sb, 0.5f * (r.Location1.Center.X + r.Location2.Center.X) - f.Size, 0.5f * (r.Location1.Center.Y + r.Location2.Center.Y) - f.Size / 2);
            }

            foreach (Cell c in map.GetCells())
            {
                //Draw Cell
                p.Color = c.CellColor;
                p.Width = c.CellLineWidth;
                g.DrawRectangle(p, c.CellRectangle);
                if (c is Location)
                {
                    //Draw Location
                    sb.Color = ((Location)c).CircleFillColor;
                    g.FillEllipse(sb, c.CellRectangle);
                    p.Color = ((Location)c).CircleColor;
                    g.DrawEllipse(p, c.CellRectangle);
                    sb.Color = ((Location)c).StringColor;
                    g.DrawString(string.Format("{0,2}", ((Location)c).LocationID), this.Font, sb, ((Location)c).Center.X - this.Font.Size, ((Location)c).Center.Y - this.Font.Size / 2);

                }
            }
            foreach (Location c in selectedLocations)
            {
                p.Color = Color.Yellow;
                p.Width = c.CellLineWidth;
                g.DrawRectangle(p, c.CellRectangle);
            }
            foreach (Location w in map.Warehouses)
            {
                foreach (Vehicle v in ((Warehouse)w.Building).Vehicles)
                {
                    v.PicBox.BringToFront();
                }
            }
            foreach (Location s in map.Shops)
            {
                ((Shop)s.Building).picBox.BringToFront();
            }

            foreach (Location w in map.Warehouses)
            {
                ((Warehouse)w.Building).picBox.BringToFront();
            }


            //---------------------------------------OLD WAY FOR DRAWING BELOW---------------------------------------
            //int cellSize = Cell.CellSize;
            //int numOfCells = map.NumberOfCells;
            //ListofRectangles = new List<Rectangle>();
            //Console.WriteLine($"Number of Cells: {numOfCells}");

            //DrawRoads(e);         

            //DrawRoadWeights(e);

            //for (int y = 0; y <= map.NumberOfCells; ++y)
            //{
            //    // (x1, y1) to (x2, y2)
            //    // With cell size 50 and the map picture box having width of 602 pixels.
            //    // Number of cells = 602 / 50, truncated thus = 12.
            //    // y = 0 || (0, 0) -> (600, 0)
            //    // y = 0 || (0, 50) -> (600, 50)
            //    // y = 0 || (0, 100) -> (600, 100)
            //    // Drawing the horizontal lines first.
            //    g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            //}
            //// The same as above but now vertical lines are drawn
            //for (int x = 0; x <= numOfCells; ++x)
            //{
            //    g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            //}
            //int k = 10;
            //foreach (Cell cell in map.GetCells())
            //{
            //    if (cell is Location)
            //    {
            //        Rectangle rect = new Rectangle(((Location)cell).LocationPoint, ((Location)cell)._Size);

            //        g.FillEllipse(new SolidBrush(Color.LightYellow), rect);
            //        g.DrawEllipse(new Pen(Color.Black), rect);
            //        g.DrawString(string.Format("{0,2}", ((Location)cell).LocationID + 1), this.Font, new SolidBrush(Color.Black), ((Location)cell).Center.X - this.Font.Size, ((Location)cell).Center.Y - this.Font.Size/2);
            //        //removed +1 from locationid above
            //        //ListofRectangles.Add(rect);
            //        //map.Locations.Add(cell.Location);
            //        k += 10;
            //    }
            //}
            //Redraw method.
            //mapPictureBox.Image = bmp;
            //------------------------------------------------------------------------------
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            //Flip isShop boolean value
            isWarehouseBtnClicked = false;
            roadModeEnabled = false;
            locationModeEnabled = false;
            isShopBtnClicked = isShopBtnClicked ? false : true;
        }

        private void mapPictureBox_MouseEnter(object sender, EventArgs e)
        {
            //Change cursor when it enters picturebox if isShop OR isWarehouse is true
            ((PictureBox)sender).Cursor = isShopBtnClicked || isWarehouseBtnClicked ? Cursors.Hand : Cursors.Arrow;

        }
        private Vehicle createNewVehicle(Point ImagePosition)
        {
            PictureBox vehiclePicBox = new PictureBox();
            vehiclePicBox.Image = Properties.Resources.vehicleIcon;
            vehiclePicBox.Location = ImagePosition;
            vehiclePicBox.Size = new Size(Cell.CellSize / 2, Cell.CellSize / 2);
            vehiclePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            splitContainer1.Panel1.Controls.Add(vehiclePicBox);
            vehiclePicBox.BringToFront();
            return new Vehicle(vehiclePicBox);
        }
        private void mapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Click detected");
            Point mousePt = new Point(e.X, e.Y);
            if (((PictureBox)sender) != mapPictureBox) //change cursor 
            {
                int x = ((PictureBox)sender).Location.X - mapPictureBox.Location.X + e.X;
                int y = ((PictureBox)sender).Location.Y - mapPictureBox.Location.Y + e.X;
                mousePt = new Point(x, y);
            }
            // Console.WriteLine("finding location at " + mousePt.X + " " + mousePt.Y);


            if (isShopBtnClicked || isWarehouseBtnClicked || roadModeEnabled)
            {
                //If the shop or warehouse button was clicked AND a rectangle was clicked. Do action.                
                foreach (Location l in map.Locations)
                {
                    if (l.CellRectangle.Contains(mousePt)) //Mouse was above some location 
                    {
                        if (roadModeEnabled)
                        {
                            if (selectedLocations.Contains(l))
                            {
                                selectedLocations.Remove(l);
                            }
                            else
                            {
                                selectedLocations.Add(l);
                                if (selectedLocations.Count == 2)
                                {
                                    int cost;
                                    if (int.TryParse(nudRoadCost.Value.ToString(), out cost))
                                    {
                                        bool succes = map.AddNewRoad(selectedLocations[0], selectedLocations[1], cost);
                                        if (!succes) //There is already a road there
                                        {
                                            map.RemoveRoad(selectedLocations[0], selectedLocations[1]);
                                            Console.WriteLine("Road from location" + selectedLocations[0].LocationID + " to location" + selectedLocations[1].LocationID + " has been removed");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Road from location" + selectedLocations[0].LocationID + " to location" + selectedLocations[1].LocationID + " has been added");
                                        }
                                        selectedLocations.Clear();
                                    }
                                    else
                                    {
                                        selectedLocations.Remove(l);
                                        MessageBox.Show("Road cost is in wrong format, only integers allowed");
                                    }

                                }
                            }
                            Map.RedrawMap();
                        }
                        else if (isShopBtnClicked || isWarehouseBtnClicked)
                        {
                            if (l.Building != null) //Remove building
                            {
                                if (l.Building is Warehouse)
                                {
                                    l.Building.picBox.Dispose();
                                    map.RemoveBuilding(l);
                                    Console.WriteLine("Warehouse has been removed from location" + l.LocationID);
                                    if (isWarehouseBtnClicked)
                                    {
                                        return;
                                    }
                                }
                                else if (l.Building is Shop)
                                {
                                    l.Building.picBox.Dispose();
                                    map.RemoveBuilding(l);
                                    Console.WriteLine("Shop has been removed from location" + l.LocationID);
                                    if (isShopBtnClicked)
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Impossible scenario");
                                }
                            }

                            //Add building
                            int id = l.LocationID;

                            //Create picturebox for building
                            PictureBox picBox = new PictureBox();
                            Point ImagePosition = new Point((l.Index.Column * Cell.CellSize) + 4, (l.Index.Row * Cell.CellSize) + 4);
                            picBox.Location = ImagePosition;
                            picBox.Size = new Size(Cell.CellSize - 1, Cell.CellSize - 1);
                            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            picBox.MouseClick += mapPictureBox_MouseClick;
                            picBox.MouseEnter += mapPictureBox_MouseEnter;

                            //Set location building
                            if (isShopBtnClicked)
                            {
                                picBox.Image = Properties.Resources.shopIcon;
                                l.Building = new Shop(500, 450);
                                l.Building.picBox = picBox;
                                Console.WriteLine("Shop has been added to location" + l.LocationID);
                            }
                            else if (isWarehouseBtnClicked)
                            {
                                picBox.Image = Properties.Resources.warehouseIcon;
                                l.Building = new Warehouse(picBox);
                                Console.WriteLine("Warehouse has been added to location" + l.LocationID);
                            }
                            map.AddNewBuilding(l);

                            //Others
                            splitContainer1.Panel1.Controls.Add(picBox); //What does this do??
                            picBox.BringToFront(); //Needs to be here and not in class Building in order to work!
                        }
                        break;
                    }
                }
            }
            else
            {
                foreach (Cell c in map.GetCells())
                {
                    if (c.CellRectangle.Contains(mousePt)) //Mouse was above some location 
                    {
                        if (locationModeEnabled)
                        {
                            if (!(c is Location))
                            {
                                Location l = map.ChangeCellIntoLocation(c);
                                map.Locations.Add(l);
                                Console.WriteLine("Cell at col: " + c.Index.Column + " row: " + c.Index.Row + " is now location" + l.LocationID);
                            }
                            else
                            {
                                Location l = (Location)c;
                                Console.WriteLine("Location" + l.LocationID + " has been removed");
                                if (l.Building != null) //Remove Building
                                {
                                    l.Building.picBox.Dispose();
                                    map.RemoveBuilding(l);
                                }
                                map.ChangeLocationIntoCell((Location)c);
                            }
                            Map.RedrawMap();
                        }
                        else
                        {
                            if (c.CellRectangle.Contains(mousePt)) //Mouse was above some location 
                            {
                                //Only allow this funtionality when simulation is not running

                                Location location = null;
                                //find the location that is in the cell thats clicked.
                                foreach (Location l in map.Locations)
                                {
                                    if (c == l)
                                    {
                                        location = l;
                                    }
                                }

                                bool isTimerOn = timer1.Enabled ? true : false;

                                CellForm cForm = new CellForm(location, c);
                                if(isTimerOn)
                                    cForm.disableFields();
                                cForm.Show();
                            }
                        }
                        break;
                    }
                }
            }

            //---------------------------------------OLD WAY BELOW---------------------------------------
            //if (isShopBtnClicked)
            //{
            //    foreach (Rectangle r in ListofRectangles)
            //    {
            //        if (r.Contains(mousePt))
            //        {
            //            Location clickedLocation = map.Get(r.X / CDIAMETER, r.Y / CDIAMETER);
            //            int id = clickedLocation.LocationID;
            //            clickedLocation.Building = new Shop(100, 10);
            //            PictureBox p = new PictureBox();
            //            Point pPoint = new Point((clickedLocation.Index.Column * CDIAMETER) + 4, (clickedLocation.Index.Row * CDIAMETER) + 4);
            //            p.Location = pPoint;
            //            p.Size = new Size(49, 49);
            //            p.Image = Properties.Resources.shopIcon;
            //            p.SizeMode = PictureBoxSizeMode.StretchImage;
            //            splitContainer1.Panel1.Controls.Add(p);
            //            p.BringToFront();
            //            lbLocationLog.Text = "Location #: " + id + " has been set to a Shop";
            //        }
            //    }
            //} else if(isWarehouseBtnClicked)
            //{
            //    foreach (Rectangle r in ListofRectangles)
            //    {
            //        if (r.Contains(mousePt))
            //        {
            //            Location clickedLocation = map.Get(r.X / CDIAMETER, r.Y / CDIAMETER);
            //            int id = clickedLocation.LocationID;
            //            clickedLocation.Building = new Warehouse(); 

            //            //warehouse expects a list of shops.. each location has a building..
            //            //i can only make a list of buildings
            //            //no clue what to do for now
            //            //check map.GetShops() for the method

            //            /*
            //             * So far i've only found 2 ways to do this. Create a picture box at the location clicked
            //             * with the warehouse image on it.
            //             * OR Redraw the image everytime with the new warehouse/shop
            //             * im including both sets of code and you guys tell me what u think
            //             * (picutrebox way still needs a small positioning fix)
            //             * (redraw method is still kinda broken)
            //             * Picturebox method admitted isnt the most efficient but i couldnt get the draw to work so i opted
            //             * for something else temporarily
            //             */
            //            PictureBox p = new PictureBox();
            //            Point pPoint = new Point((clickedLocation.Index.Column * CDIAMETER)+4, (clickedLocation.Index.Row * CDIAMETER)+4);
            //            p.Location = pPoint;
            //            p.Size = new Size(49,49);
            //            p.Image = Properties.Resources.warehouseIcon;
            //            p.SizeMode = PictureBoxSizeMode.StretchImage;
            //            splitContainer1.Panel1.Controls.Add(p);
            //            p.BringToFront();
            //            lbLocationLog.Text = "Location #: " + id + " has been set to a Warehouse";

            //            /* Redraw method
            //            using (Graphics g = Graphics.FromImage(bmp))
            //            {
            //                g.DrawRectangle(new Pen(Color.Black), new Rectangle(clickedLocation.LocationPoint, clickedLocation._Size));
            //                g.DrawImage(new Bitmap(Properties.Resources.warehouseIcon, clickedLocation._Size), clickedLocation.LocationPoint);
            //            }
            //            mapPictureBox.Image = bmp;
            //            */
            //        }
            //    }
            //}
            //------------------------------------------------------------------------------
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            //Flip warehouse bool value
            isShopBtnClicked = false;
            roadModeEnabled = false;
            locationModeEnabled = false;
            isWarehouseBtnClicked = isWarehouseBtnClicked ? false : true;
        }

        private void btnCursor_Click(object sender, EventArgs e)
        {
            //Reset Cursor and button click bools
            mapPictureBox.Cursor = Cursors.Arrow;
            isShopBtnClicked = false;
            isWarehouseBtnClicked = false;
            locationModeEnabled = false;
            roadModeEnabled = false;
        }

        private void simulateBtn_click(object sender, EventArgs e)
        {
            // For each warehouse, run Dijkstra, compare for each warehouse to store the shortest path and store those stores/shops
            // only in those warehouses.
            foreach (Location location in map.Locations)
            {
                if (location.Building != null)
                {
                    if (location.Building.GetType() == typeof(Warehouse))
                    {
                        map.Warehouses.Add(location);
                    }
                }
            }

            foreach (Location warehouse in map.Warehouses)
            {
                // Traverse shortest paths from warehouse to all other locations.
                Map.Dijkstra(map, warehouse.LocationID);
                foreach (Location location in map)
                {
                    if (location.LocationID != warehouse.LocationID)
                    {
                        if (location.Building != null)
                        {
                            if (location.Building.GetType() == typeof(Shop))
                            {
                                Road r = new Road(warehouse, location);
                                // This is done as an intermediary step to compare different min costs (which belong to a vertex) later on.
                                // Otherwise there was no way to compare the distance from different warehouses to the same shop (as information
                                // gets lost because we have to reset the values of vertices to rerun Dijkstra multiple times.
                                r.InitialCost = location.min_cost;
                                ((Warehouse)warehouse.Building).Roads.Add(r);
                            }
                        }
                    }
                    location.min_cost = int.MaxValue;
                    location.permanent = false;
                    location.visited = false;
                }
            }

            int shortestPath = int.MaxValue;
            Road shortestRoad = null;

            for (int i = 0; i < ((Warehouse)map.Warehouses[0].Building).Roads.Count; i++)
            {
                for (int j = 0; j < map.Warehouses.Count; j++)
                {
                    if (j == 0)
                    {
                        shortestPath = ((Warehouse)map.Warehouses[j].Building).Roads[i].InitialCost;
                        shortestRoad = ((Warehouse)map.Warehouses[j].Building).Roads[i];
                    }
                    else
                    {
                        if (((Warehouse)map.Warehouses[j].Building).Roads[i].InitialCost < shortestPath)
                        {
                            shortestPath = ((Warehouse)map.Warehouses[j].Building).Roads[i].InitialCost;
                            shortestRoad = ((Warehouse)map.Warehouses[j].Building).Roads[i];
                        }
                    }
                }
                // Display.
                shortesRoutesRichTbx.Text += $"Warehouses at #{shortestRoad[0].LocationID + 1} to shop at #{shortestRoad[1].LocationID + 1}, takes {shortestRoad.InitialCost} km.\n";
            }
        }

        private void btnDrawRoute_Click(object sender, EventArgs e)
        {
            int TolocationID = int.Parse(tbToLocationID.Text);
            Location destination = map.GetLocationByID(TolocationID);
            int FromlocationID = int.Parse(tbFromLocationID.Text);
            Location start = map.GetLocationByID(FromlocationID);

            DijkstraRoute myRoute = map.DistManager.DistDijkstra.GetRouteTo(start, destination);
            List<Road> allRoads = map.Edges;
            foreach (Road r in allRoads)
            {
                r.ResetDrawFields();
            }
            foreach (Road r in myRoute.Route)
            {
                r.LineColor = Color.Green;
            }
            Map.RedrawMap();
        }

        private void btnGetRoute_Click(object sender, EventArgs e)
        {
            int TolocationID = int.Parse(tbToLocationID.Text);
            Location destination = map.GetLocationByID(TolocationID);
            int FromlocationID = int.Parse(tbFromLocationID.Text);
            Location start = map.GetLocationByID(FromlocationID);
            DijkstraRoute myRoute = map.DistManager.DistDijkstra.GetRouteTo(start, destination);

            string holder = "From " + FromlocationID + " to " + TolocationID + ": \n";
            foreach (Road r in myRoute.Route)
            {
                holder += "Road: " + r.Location1.LocationID + " - " + r.Location2.LocationID + "\n";
            }
            MessageBox.Show(holder);
        }

        private void btnDrawDijkstra_Click(object sender, EventArgs e)
        {
            int FromlocationID = int.Parse(tbFromLocationID.Text);
            Location start = map.GetLocationByID(FromlocationID);

            map.DistManager.DistDijkstra.PlayDijkstraAnimation(start);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeStampCounter++;
            map.NextTick(timeStampCounter);
            string holder = "";
            foreach (Location s in map.Shops)
            {
                holder += "SHOP" + s.LocationID + " stock: " + ((Shop)s.Building).Stock + " Restock: " + ((Shop)s.Building).RestockAmount + "\n";
            }
            holder += "Cell Max D: " + Cell.MaxDemand + " DG: " + Cell.MaxDemandGrow + "\n";
            foreach (Cell c in map.GetCells())
            {
                holder += "Cell (" + c.Index.Column + "," + c.Index.Row + ") D: " + c.Demand + " DG: " + c.DemandGrowthPerTick + "\n";
            }
            shortesRoutesRichTbx.Clear();
            shortesRoutesRichTbx.Text += holder;
            if (drawHeatMap) { Map.RedrawMap(); }

        }

        int timeStampCounter = 0;
        private void btnStartSimulation_Click(object sender, EventArgs e)
        {
            createAllvehicles();
            map.PrepareForSimulation();
            Map.RedrawMap();
            timer1.Enabled = true;
            btnCursor.Enabled = true;
            btnWarehouse.Enabled = false;
            btnShop.Enabled = false;
            btnRoadMode.Enabled = false;
            btnLocationMode.Enabled = false;
            btnCursor_Click(this, new EventArgs());
        }
        private void createAllvehicles()
        {
            foreach (Location l in map.Warehouses)
            {
                Point ImagePosition = new Point((l.Index.Column * Cell.CellSize) + 4, (l.Index.Row * Cell.CellSize) + 4);
                Warehouse w = (Warehouse)l.Building;

                for (int i = 1; i <= w.TotalVehiclesAtStart; i++)
                {
                    Vehicle temp = createNewVehicle(ImagePosition);
                    w.AddVehicle(temp);
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }
        private bool drawHeatMap = false;
        private void btnHeatMap_Click(object sender, EventArgs e)
        {
            drawHeatMap = !drawHeatMap;
            Map.RedrawMap();
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            int speed = int.Parse(tbFromLocationID.Text);
            timer1.Interval = speed;
        }

        private bool roadModeEnabled = false;
        private void btnRoadMode_Click(object sender, EventArgs e)
        {
            roadModeEnabled = true;
            isWarehouseBtnClicked = false;
            isShopBtnClicked = false;
            locationModeEnabled = false;
        }

        private bool locationModeEnabled = false;
        private void btnLocationMode_Click(object sender, EventArgs e)
        {
            locationModeEnabled = true;
            roadModeEnabled = false;
            isWarehouseBtnClicked = false;
            isShopBtnClicked = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (context = new SimulationContext())
            {
                // Add all cells to the list at the end for storage.
                map.Cells.Clear();
                foreach (Cell c in map.GetCells())
                {
                    map.Cells.Add(c);
                }

                context.Maps.Add(map);
                context.SaveChanges();
            }
        }
    }
}
