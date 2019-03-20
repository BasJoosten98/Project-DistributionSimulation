using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Map
    {
        private Random rng;
        //atributes for the map
        //private List<Cell> cells;
        private Cell[,] cells;

        public int NumOfCells { get; set; }

        public Map(int numberOfLocations, int numOfCells, int cellSize)
        {
            NumOfCells = numOfCells;
            Cell.CellSize = cellSize;
            cells = new Cell[NumOfCells, NumOfCells];
            for (int rowCount = 0; rowCount < NumOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumOfCells; columnCount++)
                {
                    cells[rowCount, columnCount] = new Cell(rowCount, columnCount);
                }
            }
            // Seed the random generator to get reproducable results.
            rng = new Random(0);

            while (numberOfLocations > 0)
            {
                Cell c = GenerateRandomLocation();
                if (c.Location == null)
                {
                    // Set location object to beparth of this cell 
                    // and decrement number of locations to be added to the cells/map.
                    c.Location = new Location(c.Index.Row, c.Index.Column);
                    numberOfLocations--;
                }
            }
        }

        public Cell[,] GetCells()
        {
            // Preferably this will be a copy, and perhaps not a shallow one.
            return cells;
        }

        private Cell GenerateRandomLocation()
        {
            // Return a cell at index [x, y] where x and y are numbers between 0 and NumOfCells (exclusive)
            return cells[rng.Next(0, NumOfCells), rng.Next(0, NumOfCells)]; 
        }
    }
}
