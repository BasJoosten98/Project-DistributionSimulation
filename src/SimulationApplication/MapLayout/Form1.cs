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
        List<Rectangle> ListofRectangles;
        //redraw image method
        //Bitmap bmp;
        

        public Form1()
        {
            InitializeComponent();

            // This could be set later on, maybe even via the app config file or by the user.
            const int CELLSIZE = 50;

            // The result represents the number of cells we can create in both width and height (Square grid/map) based on the cell size.
            int numberOfCells = mapPictureBox.Width / CELLSIZE;
            map = new Map(numberOfLocations: 10, numberOfCells: numberOfCells, cellSize: CELLSIZE);


            // This loop is for debugging purposes such that we can check which cells have a location added to them.
            foreach (Cell cell in map.GetCells())
            {
                if (cell.Location != null)
                {
                    Console.WriteLine($"Row: {cell.Index.Row}, Col: {cell.Index.Column}");  
                }
            }
            //reDraw image method
            //bmp = new Bitmap(mapPictureBox.Width,mapPictureBox.Height);
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            int cellSize = Cell.CellSize;
            int numOfCells = map.NumberOfCells;
            ListofRectangles = new List<Rectangle>();
            Console.WriteLine($"Number of Cells: {numOfCells}");


            //change to Graphics.FromImage(bmp) for redraw 
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            DrawRoads(e);

            for (int y = 0; y <= map.NumberOfCells; ++y)
            {
                // (x1, y1) to (x2, y2)
                // With cell size 50 and the map picture box having width of 602 pixels.
                // Number of cells = 602 / 50, truncated thus = 12.
                // y = 0 || (0, 0) -> (600, 0)
                // y = 0 || (0, 50) -> (600, 50)
                // y = 0 || (0, 100) -> (600, 100)
                // Drawing the horizontal lines first.
         
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);

            }

            // The same as above but now vertical lines are drawn
            for (int x = 0; x <= numOfCells; ++x)
            {

                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);

            }
            int k = 10;
            foreach (Cell cell in map.GetCells())
            {
                if (cell.Location != null)
                {
                    Rectangle rect = new Rectangle(cell.Location.LocationPoint, cell.Location._Size);

                    g.FillEllipse(new SolidBrush(Color.LightYellow), rect);
                    g.DrawEllipse(new Pen(Color.Black), rect);
                    g.DrawString(string.Format("{0,2}", cell.Location.LocationID + 1), this.Font, new SolidBrush(Color.Black), cell.Location.LocationPoint.X +17, cell.Location.LocationPoint.Y + 20);
                    //removed +1 from locationid above
                    ListofRectangles.Add(rect);
                    //map.Locations.Add(cell.Location);
                    k += 10;
                }
            }
            DrawRoadWeights(e);
            //Redraw method.
            //mapPictureBox.Image = bmp;
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
            mapPictureBox.Cursor = isShopBtnClicked || isWarehouseBtnClicked ? Cursors.Hand : Cursors.Arrow; 
        }

        private void mapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //If the shop or warehouse button was clicked AND a rectangle was clicked. Do action.
            Point mousePt = new Point(e.X, e.Y);
            int CDIAMETER = 50;
            if (isShopBtnClicked)
            {
                foreach (Rectangle r in ListofRectangles)
                {
                    if (r.Contains(mousePt))
                    {
                        Location clickedLocation = map.Get(r.X / CDIAMETER, r.Y / CDIAMETER);
                        int id = clickedLocation.LocationID;
                        clickedLocation.Building = new Shop(100, 10);
                        PictureBox p = new PictureBox();
                        Point pPoint = new Point((clickedLocation.PositionX * CDIAMETER) + 4, (clickedLocation.PositionY * CDIAMETER) + 4);
                        p.Location = pPoint;
                        p.Size = clickedLocation._Size;
                        p.Image = Properties.Resources.shopIcon;
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        splitContainer1.Panel1.Controls.Add(p);
                        p.BringToFront();
                        lbLocationLog.Text = "Location #: " + id + " has been set to a Shop";
                    }
                }
            } else if(isWarehouseBtnClicked)
            {
                foreach (Rectangle r in ListofRectangles)
                {
                    if (r.Contains(mousePt))
                    {
                        Location clickedLocation = map.Get(r.X / CDIAMETER, r.Y / CDIAMETER);
                        int id = clickedLocation.LocationID;
                        clickedLocation.Building = new Warehouse(); 

                        //warehouse expects a list of shops.. each location has a building..
                        //i can only make a list of buildings
                        //no clue what to do for now
                        //check map.GetShops() for the method

                        /*
                         * So far i've only found 2 ways to do this. Create a picture box at the location clicked
                         * with the warehouse image on it.
                         * OR Redraw the image everytime with the new warehouse/shop
                         * im including both sets of code and you guys tell me what u think
                         * (picutrebox way still needs a small positioning fix)
                         * (redraw method is still kinda broken)
                         * Picturebox method admitted isnt the most efficient but i couldnt get the draw to work so i opted
                         * for something else temporarily
                         */
                        PictureBox p = new PictureBox();
                        Point pPoint = new Point((clickedLocation.PositionX * CDIAMETER)+4, (clickedLocation.PositionY * CDIAMETER)+4);
                        p.Location = pPoint;
                        p.Size = new Size(49,49);
                        p.Image = Properties.Resources.warehouseIcon;
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        splitContainer1.Panel1.Controls.Add(p);
                        p.BringToFront();
                        lbLocationLog.Text = "Location #: " + id + " has been set to a Warehouse";
                            
                        /* Redraw method
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawRectangle(new Pen(Color.Black), new Rectangle(clickedLocation.LocationPoint, clickedLocation._Size));
                            g.DrawImage(new Bitmap(Properties.Resources.warehouseIcon, clickedLocation._Size), clickedLocation.LocationPoint);
                        }
                        mapPictureBox.Image = bmp;
                        */
                    }
                }
            }
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

        private void DrawRoads(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Road road in map.Edges)
            {
                e.Graphics.DrawLine(new Pen(Color.IndianRed, 3), road[0].Center, road[1].Center);
            }
        }

        private void DrawRoadWeights(PaintEventArgs e)
        {
            foreach (Road road in map.Edges)
            {
                e.Graphics.DrawString(road.initialCost.ToString(), Font, new SolidBrush(Color.White), 0.5f * (road[0].Center.X + road[1].Center.X), 0.5f * (road[0].Center.Y + road[1].Center.Y));
            }
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
                                r.initialCost = location.min_cost;
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
    }
}
