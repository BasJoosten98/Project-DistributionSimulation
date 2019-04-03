using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Index
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Index (int columnNumber, int rowNumber)
        {
            Row = rowNumber;
            Column = columnNumber;
        }

        public override string ToString()
        {
            return $"(r:{Row}, c:{Column})";
        }
    }
}
