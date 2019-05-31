using System;
using ClassLibrary;


namespace DataBaseTestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a map and test if the returned value is the right id.
            Map m = new Map(10, 13, 40);
            m.Locations[0].Building = new Shop(500, 210);
            m.Locations[1].Building = new Shop(200, 100);
            m.Locations[2].Building = new Warehouse();
            Console.WriteLine(m.NumberOfCells);
            Console.WriteLine(m.CellSize);
            m.Save();
            Console.WriteLine(m.Id);
            Console.ReadKey();
        }
    }
}
