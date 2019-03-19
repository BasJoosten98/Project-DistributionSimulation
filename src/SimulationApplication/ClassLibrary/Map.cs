using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
    public class Map
    {
        Random rng;
        //atributes for the map
        private List<Cell> cells;

        public int NumOfCells { get; set; }

        public Map(int numberOfLocations, int numOfCells, int cellSize)
        {
            NumOfCells = numOfCells;

            Cell.CellSize = cellSize;

            cells = new List<Cell>();

            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    cells.Add(new Cell(i, j));
                }
            }
            rng = new Random(0);

            while (numberOfLocations > 0)
            {
                Cell c = GenerateRandomLocation();
                if (c.Location == null)
                {
                    // set location and decrement number of locations.
                    c.Location = new Location(c.Column, c.Row);
                    numberOfLocations--;
                }
            }
        }

        public List<Cell> GetCells()
        {
            return new List<Cell>(cells);
        }

        private Cell GenerateRandomLocation()
        {
            return cells[rng.Next(0, cells.Count)]; 
        }
    }
}
