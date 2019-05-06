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
            if(mapPictureBox.Width <= mapPictureBox.Height) { numberOfCells = mapPictureBox.Width / CELLSIZE; }
            else { numberOfCells = mapPictureBox.Height / CELLSIZE; }
            map = new Map(numberOfLocations: 10, numberOfCells: numberOfCells, cellSize: CELLSIZE, MapBox: mapPictureBox);

            // Remove this line in case we do not want to make use of the hard coded edges anymore.
            map.AddHardCodedEdges();

            //This loop is for debugging purposes such that we can check which cells have a location added to them.
            foreach (Cell cell in map.GetCells())
                {
                    if (cell is Location)
                    {
                        Console.WriteLine($"Row: {cell.Index.Row}, Col: {cell.Index.Column}");
                    }
                }
            //reDraw image method
            //bmp = new Bitmap(mapPictureBox.Width,mapPictureBox.Height);
        }


        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            //change to Graphics.FromImage(bmp) for redraw 
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);

            foreach(Road r in map.Edges) 
            {
                //Draw Line
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                p.Color = r.LineColor;
                p.Width = r.LineWidth;
                g.DrawLine(p, r.Vertex1.Center, r.Vertex2.Center);

                //Draw String
                sb.Color = r.StringColor;
                g.DrawString(r.initialCost.ToString(), this.Font, sb, 0.5f * (r.Vertex1.Center.X + r.Vertex2.Center.X) - this.Font.Size, 0.5f * (r.Vertex1.Center.Y + r.Vertex2.Center.Y) - this.Font.Size / 2);
            }

            foreach(Cell c in map.GetCells())
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
            isShopBtnClicked = isShopBtnClicked ? false : true;
        }

        private void mapPictureBox_MouseEnter(object sender, EventArgs e)
        {
            //Change cursor when it enters picturebox if isShop OR isWarehouse is true
            ((PictureBox)sender).Cursor = isShopBtnClicked || isWarehouseBtnClicked ? Cursors.Hand : Cursors.Arrow; 
            
        }

        private void mapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Click detected");
            if (isShopBtnClicked || isWarehouseBtnClicked)
            {
                //If the shop or warehouse button was clicked AND a rectangle was clicked. Do action.
                Point mousePt = new Point(e.X, e.Y);
                if(((PictureBox)sender) != mapPictureBox) //change cursor 
                {
                    int x = ((PictureBox)sender).Location.X - mapPictureBox.Location.X + e.X;
                    int y = ((PictureBox)sender).Location.Y - mapPictureBox.Location.Y + e.X;
                    mousePt = new Point(x, y);
                }
                //int CDIAMETER = 50;
                Console.WriteLine("finding location at "+ mousePt.X +" "+ mousePt.Y);
                foreach (Location l in map.Locations)
                {
                    if (l.CellRectangle.Contains(mousePt)) //Mouse was above some location 
                    {
                        Console.WriteLine("location found");
                        int id = l.LocationID;
                        PictureBox picBox = new PictureBox();
                        Point ImagePosition = new Point((l.Index.Column * Cell.CellSize) + 4, (l.Index.Row * Cell.CellSize) + 4);
                        picBox.Location = ImagePosition;
                        picBox.Size = new Size(Cell.CellSize - 1, Cell.CellSize - 1);
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picBox.MouseClick += mapPictureBox_MouseClick;
                        picBox.MouseEnter += mapPictureBox_MouseEnter;
                        if (isShopBtnClicked)
                        {
                            picBox.Image = Properties.Resources.shopIcon;
                            l.Building = new Shop(picBox, 100, 10);
                            //lbLocationLog.Text = "Location #: " + id + " has been set to a Shop";
                            Console.WriteLine("Location #: " + id + " has been set to a Shop");
                        }
                        else if (isWarehouseBtnClicked)
                        {
                            picBox.Image = Properties.Resources.warehouseIcon;
                            l.Building = new Warehouse(picBox);
                            //lbLocationLog.Text = "Location #: " + id + " has been set to a WareHouse";
                            Console.WriteLine("Location #: " + id + " has been set to a WareHouse");
                        }
                        splitContainer1.Panel1.Controls.Add(picBox); //What does this do??
                        picBox.BringToFront(); //Needs to be here and not in class Building in order to work!
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
            isWarehouseBtnClicked = isWarehouseBtnClicked ? false : true;
        }

        private void btnCursor_Click(object sender, EventArgs e)
        {
            //Reset Cursor and button click bools
            mapPictureBox.Cursor = Cursors.Arrow;
            isShopBtnClicked = false;
            isWarehouseBtnClicked = false;
        }

        //private void DrawRoads(PaintEventArgs e)
        //{
        //    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    foreach (Road road in map.Edges)
        //    {
        //        e.Graphics.DrawLine(new Pen(Color.IndianRed, 3), road[0].Center, road[1].Center);
        //    }
        //}

        //private void DrawRoadWeights(PaintEventArgs e)
        //{
        //    foreach (Road road in map.Edges)
        //    {
        //        e.Graphics.DrawString(road.initialCost.ToString(), Font, new SolidBrush(Color.White), 0.5f * (road[0].Center.X + road[1].Center.X), 0.5f * (road[0].Center.Y + road[1].Center.Y));
        //    }
        //}

        private void simulateBtn_click(object sender, EventArgs e)
        {
            // For each warehouse, run Dijkstra, compare for each warehouse to store the shortest path and store those stores/shops
            // only in those warehouses.
            foreach (Location location in map.Locations)
            {
                if (location.Building != null)
                {
                    if (location.Building is Warehouse)
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

                    if (location.LocationID != warehouse.LocationID && 
                        location.Building != null && 
                        location.Building.GetType() == typeof(Shop)
                        )
                    {
                                Road r = new Road(warehouse, location);
                                // This is done as an intermediary step to compare different min costs (which belong to a vertex) later on.
                                // Otherwise there was no way to compare the distance from different warehouses to the same shop (as information
                                // gets lost because we have to reset the values of vertices to rerun Dijkstra multiple times.
                                r.initialCost = location.min_cost;
                                ((Warehouse)warehouse.Building).Roads.Add(r);
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
                        shortestPath = ((Warehouse)map.Warehouses[j].Building).Roads[i].initialCost;
                        shortestRoad = ((Warehouse)map.Warehouses[j].Building).Roads[i];
                    }
                    else
                    {
                        if (((Warehouse)map.Warehouses[j].Building).Roads[i].initialCost < shortestPath)
                        {
                            shortestPath = ((Warehouse)map.Warehouses[j].Building).Roads[i].initialCost;
                            shortestRoad = ((Warehouse)map.Warehouses[j].Building).Roads[i];
                        }
                    }
                }
                // Display.
                shortesRoutesRichTbx.Text += $"Warehouses at #{shortestRoad[0].LocationID + 1} to shop at #{shortestRoad[1].LocationID + 1}, takes {shortestRoad.initialCost} km.\n";
            }
        }

        Dijkstra myDijkstra;
        private void btnTestDijkstra_Click(object sender, EventArgs e)
        {
            myDijkstra = new Dijkstra(map.Edges);
        }

        private void btnDrawRoute_Click(object sender, EventArgs e)
        {
            int TolocationID = int.Parse(tbToLocationID.Text);
            Location destination = map.GetLocationByID(TolocationID);
            int FromlocationID = int.Parse(tbFromLocationID.Text);
            Location start = map.GetLocationByID(FromlocationID);

            DijkstraRoute myRoute = myDijkstra.GetRouteTo(start, destination);
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
            DijkstraRoute myRoute = myDijkstra.GetRouteTo(start, destination);

            string holder = "From " + FromlocationID + " to " + TolocationID + ": \n";
            foreach (Road r in myRoute.Route)
            {
                holder += "Road: " + r.Vertex1.LocationID + " - " + r.Vertex2.LocationID + "\n";
            }
            MessageBox.Show(holder);
        }

        private void btnDrawDijkstra_Click(object sender, EventArgs e)
        {
            int FromlocationID = int.Parse(tbFromLocationID.Text);
            Location start = map.GetLocationByID(FromlocationID);

            myDijkstra.PlayDijkstraAnimation(start);
        }
    }
}
