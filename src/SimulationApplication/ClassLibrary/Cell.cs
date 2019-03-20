using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Cell
    {
        // Some fields that determine the attractiveness.
        public static int CellSize { get; set; }
        public Index Index { get; set; }
        public Location Location { get; set; }

        public Cell(int row, int column)
        {
            Index = new Index(row, column);
        }
    }
}
