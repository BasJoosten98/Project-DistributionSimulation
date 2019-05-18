using ClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace DataBaseTestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassLibrary.SimulationContext context;
            using (context = new ClassLibrary.SimulationContext())
            {
                context.Database.EnsureCreatedAsync();
            }

            // Create a map with a location and add a shop object into that location and store it into the db.
            Map m = new Map() { NumberOfCells = 10, CellSize = 20 };
            m.Locations = new List<Location>()
            {
                new Location() { RowIndex = 0, ColumnIndex = 0, Building = new Shop() { Stock = 100, RestockAmount = 20 } },
                new Location() { RowIndex = 0, ColumnIndex = 1, Building = new Warehouse() },
                new Location() { RowIndex = 0, ColumnIndex = 2 }
            };

            using (context = new ClassLibrary.SimulationContext())
            {
                context.Maps.Add(m);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
