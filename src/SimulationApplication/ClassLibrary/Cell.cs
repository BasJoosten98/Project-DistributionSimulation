using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Cell
    {
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
        public virtual void DrawMe(Graphics g, Pen p)
        {
            g.DrawRectangle(p, CellRectangle);
        }
    }
}
