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
        public static int CellSize { get; set; }
        public Index Index { get; set; }
        //public Location Location { get; set; }
        public Rectangle CellRectangle;

        public Cell(int columnNumber, int rowNumber)
        {
            Index = new Index(columnNumber, rowNumber);
            CellRectangle = new Rectangle(new Point(Index.Column * CellSize, Index.Row * CellSize), new Size(CellSize, CellSize));
        }

        public virtual void ResetDrawFields()
        {
            CellColor = Color.Black;
            CellLineWidth = 1;
        }
    }
}
