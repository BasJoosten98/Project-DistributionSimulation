using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Cell
    {
        //drawing fields
        public Color CellColor = Color.Black;
        public int CellLineWidth = 1;


        // Some fields that determine the attractiveness.
        //TODO: Should be getting a more complex backing field
        private static int maxDemand = 0;
        private int demand;
        public int Demand { get; }
        public static int CellSize { get; set; }
        public Index Index { get; set; }
        //public Location Location { get; set; }
        public Rectangle CellRectangle;

        public Cell(int columnNumber, int rowNumber, int demand)
        {
            Index = new Index(columnNumber, rowNumber);
            CellRectangle = new Rectangle(new Point(Index.Column * CellSize, Index.Row * CellSize), new Size(CellSize, CellSize));
            SetDemand(demand);
        }
        public Cell(int columnNumber, int rowNumber) : this(columnNumber, rowNumber, 0)
        { }

        public virtual void ResetDrawFields()
        {
            CellColor = Color.Black;
            CellLineWidth = 1;
        }
        public void SetDemand(int Demand)
        {
            this.demand = Demand;
            if(Demand > maxDemand)
            {
                maxDemand = Demand;
            }
        }
        public Color GetHeatMapCellColor()
        {
            double greenColor = Math.Floor(50 + (double)this.demand/ (double)maxDemand * 205);
            Color heatColor = Color.FromArgb(0, (int)greenColor, 0);
            return heatColor;
        }
    }
}
