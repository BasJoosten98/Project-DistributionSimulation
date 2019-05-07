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
        public int Demand { get; set; }
        public static int CellSize { get; set; }
        public Index Index { get; set; }
        //public Location Location { get; set; }
        public Rectangle CellRectangle;

        public Cell(int columnNumber, int rowNumber, int demand)
        {
            Index = new Index(columnNumber, rowNumber);
            CellRectangle = new Rectangle(new Point(Index.Column * CellSize, Index.Row * CellSize), new Size(CellSize, CellSize));
            Demand = demand;
        }
        public Cell(int columnNumber, int rowNumber) : this(columnNumber, rowNumber, 0)
        { }

        /// <summary>
        ///It sets the collor of the cell to black and the width to 1
        /// </summary>
        public virtual void ResetDrawFields()
        {
            CellColor = Color.Black;
            CellLineWidth = 1;
        }
    }
}
