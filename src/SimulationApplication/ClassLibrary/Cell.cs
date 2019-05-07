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
        public int Demand { get { return this.demand; } }
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
            double maxPercentage = (double)this.demand / maxDemand;
            Color heatColor;
            if(maxPercentage >= 0.5) //green
            {
                double otherColors = 255 - Math.Floor((maxPercentage - 0.5) * 2 * 255); 
                heatColor = Color.FromArgb((int)otherColors, 255, (int)otherColors);
            }
            else //red
            {
                double otherColors = 255 - Math.Floor((0.5 - maxPercentage) * 2 * 255);
                heatColor = Color.FromArgb(255, (int) otherColors, (int)otherColors);
            }
             
            return heatColor;
        }
    }
}
