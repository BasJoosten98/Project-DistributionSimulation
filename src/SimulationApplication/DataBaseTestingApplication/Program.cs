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
            Console.WriteLine(m.NumberOfCells);
            Console.WriteLine(m.CellSize);
            m.Save();
            Console.WriteLine(m.Id);
            Console.ReadKey();
        }
    }
}
