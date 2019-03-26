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
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            int cellSize = Cell.CellSize;
            int numOfCells = map.NumberOfCells;
            ListofRectangles = new List<Rectangle>();
            Console.WriteLine($"Number of Cells: {numOfCells}");



            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

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
                    Rectangle rect = new Rectangle(cell.Location.Locationn, cell.Location._Size);

                    g.FillEllipse(new SolidBrush(Color.LightYellow), rect);
                    g.DrawEllipse(new Pen(Color.Black), rect);
                    g.DrawString(string.Format("{0,2}", cell.Location.LocationID + 1), this.Font, new SolidBrush(Color.Black), cell.Location.Locationn.X +17, cell.Location.Locationn.Y + 20);
                    ListofRectangles.Add(rect);
                    k += 10;
                }
            }
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
            if (isShopBtnClicked)
            {
                foreach (Rectangle r in ListofRectangles)
                {
                    if (r.Contains(mousePt)) MessageBox.Show("Shop Set");
                }
           
            } else if(isWarehouseBtnClicked)
            {
                foreach (Rectangle r in ListofRectangles)
                {
                    if (r.Contains(mousePt)) MessageBox.Show("Warehouse Set");
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
    }
}
