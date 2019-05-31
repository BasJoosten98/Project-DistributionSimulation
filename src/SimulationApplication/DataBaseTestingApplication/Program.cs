using System;
using ClassLibrary;


namespace DataBaseTestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random(0);

            // Create a map and test if the returned value is the right id.
            Map m = new Map(10, 13, 40);
            m.Locations[0].Building = new Shop(500, 210);
            m.Locations[1].Building = new Shop(200, 100);
            m.Locations[2].Building = new Warehouse();

            m.Edges.Add(new Road(m.Locations[0], m.Locations[1], rng.Next(2, 5)));
            Console.WriteLine($"Created a road from {m.Locations[0]} to {m.Locations[1]}");

            m.Edges.Add(new Road(m.Locations[1], m.Locations[2], rng.Next(2, 5)));
            Console.WriteLine($"Created a road from {m.Locations[1]} to {m.Locations[2]}");

            m.Edges.Add(new Road(m.Locations[2], m.Locations[0], rng.Next(2, 5)));
            Console.WriteLine($"Created a road from {m.Locations[2]} to {m.Locations[0]}");

            Console.WriteLine(m.NumberOfCells);
            Console.WriteLine(m.CellSize);
            m.Save();
            Console.WriteLine(m.Id);
            Console.ReadKey();
        }
    }
}
