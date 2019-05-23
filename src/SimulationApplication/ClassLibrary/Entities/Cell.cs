using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Cell
    {
        public int Id { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Demand { get; set; }
        public int DemandGrowthPerTick { get; set; }

        // Foreign Key
        public int MapId { get; set; }
        public Map Map { get; set; }
    }
}
