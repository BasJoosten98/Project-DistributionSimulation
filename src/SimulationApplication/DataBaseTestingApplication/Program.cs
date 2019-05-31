using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data; // IMPORTANT TO USE LAMBDAS AS WHERE ETC.
using ClassLibrary;

namespace DataBaseTestingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DataBase.ConnectionInfo);
            Console.ReadKey();
        }
    }
}
