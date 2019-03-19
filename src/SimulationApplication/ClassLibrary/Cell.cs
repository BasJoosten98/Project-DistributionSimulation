using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationApplication.ClassLibrary
{
    public class Cell
    {
        // Some fields that determine the attractiveness.
        public static int CellSize { get; set; }

        public int Column { get; }
        public int Row { get; }
        public Location Location { get; set; }

        public Cell(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
