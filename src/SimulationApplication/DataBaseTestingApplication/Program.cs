using ClassLibrary;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationContext context = new SimulationContext();

            using (context)
            {
                context.Database.EnsureCreatedAsync();
            }

            Console.ReadKey();
        }
    }
}
