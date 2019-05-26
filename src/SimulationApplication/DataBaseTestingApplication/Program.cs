using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; // IMPORTANT TO USE LAMBDAS AS WHERE ETC.
using Microsoft.EntityFrameworkCore; // IMPORTANT TO MAKE A CALL TO INCLUDE

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
                Console.WriteLine("Creating the db");
            }

            // Create a map with a location and add a shop object into that location and store it into the db.
            //Map m = new Map() { NumberOfCells = 10, CellSize = 20 };
            //Location l1 = new Location() { RowIndex = 0, ColumnIndex = 0, Building = new Shop() { Stock = 100, RestockAmount = 20 } };
            //Location l2 = new Location() { RowIndex = 0, ColumnIndex = 1, Building = new Warehouse() };

            //m.Cells = new List<Cell>()
            //{
            //    l1,
            //    l2,
            //    new Location() { RowIndex = 0, ColumnIndex = 2 }
            //};

            //m.Roads = new List<Road>()
            //{
            //    new Road() { InitialCost=2, Location1 = l1, Location2 = l2 }
            //};

            //using (context = new ClassLibrary.SimulationContext())
            //{
            //    context.Maps.Add(m);
            //    context.SaveChanges();
            //}
            //Map m = null;
            //using (context = new ClassLibrary.SimulationContext())
            //{
            //    m = context.Maps
            //        .Where(map => map.Id == 1)
            //        .Include(map => map.Cells)
            //        .Include(map => map.Roads)
            //        .FirstOrDefault();
            //}

            //Console.WriteLine();
            //Console.WriteLine(m.Id);
            //Console.WriteLine();

            //foreach (Cell c in m.Cells)
            //{
            //    Console.WriteLine($"id: {c.Id}, r: {c.RowIndex}, c: {c.ColumnIndex}, isLocation: {c is Location}");
            //}
            //Console.WriteLine();
            //foreach (Road r in m.Roads)
            //{
            //    Console.WriteLine(r);
            //    Console.WriteLine(r.Location1.Id);
            //}
            //Console.WriteLine();
            Console.ReadKey();
        }
    }
}
