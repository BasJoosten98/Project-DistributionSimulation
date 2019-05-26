using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Cell
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Demand { get; set; }
        public int DemandGrowthPerTick { get; set; }

        // Foreign Key
        public int MapId { get; set; }
        public Map Map { get; set; }

        public Cell(Map map, int rowIndex, int columnIndex) : this(map, rowIndex, columnIndex, 0)
        { }

        public Cell(Map map, int rowIndex, int columnIndex, int demand)
        {
            Map = map;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Demand = demand;
            DemandGrowthPerTick = demand;
        }

        public override string ToString()
        {
            return $"Cell: ({RowIndex}, {ColumnIndex})";
        }
    }
}
