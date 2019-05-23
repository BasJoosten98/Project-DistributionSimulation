using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    class Cell
    {
        public int MapId { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Demand { get; set; }
    }
}
