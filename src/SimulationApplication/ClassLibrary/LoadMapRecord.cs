using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class LoadMapRecord
    {
        public int Id { get; }
        public int NumberOfCells { get; }
        public int CellSize { get; }

        public LoadMapRecord(int id, int numberOfCells, int cellSize)
        {
            Id = id;
            NumberOfCells = numberOfCells;
            CellSize = cellSize;

        }

        public override string ToString()
        {
            return $"Map: {Id}, Number of cells: {NumberOfCells}, Cell size: {CellSize}";
        }
    }
}
