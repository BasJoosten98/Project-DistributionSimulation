using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulationApplication.ClassLibrary;
namespace MapLayout
{
    public partial class Form1 : Form
    {
        private Map map;
        public Form1()
        {
            InitializeComponent();
            int w = pictureBox1.Width / 50;
            map = new Map(w, 50);
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            int cellSize = Cell.CellSize;
            int numOfCells = map.NumOfCells;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < map.NumOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
