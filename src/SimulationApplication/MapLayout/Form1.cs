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
        public Form1()
        {
            InitializeComponent();

            // This could be set later on, maybe even via the app config file or by the user.
            const int CELLSIZE = 50;

            // The result represents the number of cells we can create in both width and height (Square grid/map) based on the cell size.
            int numberOfCells = mapPictureBox.Width / CELLSIZE;
            map = new Map(numberOfLocations: 10, numOfCells: numberOfCells, cellSize: CELLSIZE);

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
            int numOfCells = map.NumOfCells;

            Console.WriteLine($"Number of Cells: {numOfCells}");

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y <= map.NumOfCells; ++y)
            {
                // (x1, y1) to (x2, y2)
                // 
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x <= numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
