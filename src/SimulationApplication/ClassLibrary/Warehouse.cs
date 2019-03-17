using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
	public class Warehouse : Building
	{
		List<Vehicle> vehicles;
		List<Shop> queue;

        public Warehouse():base()
        {
            
        }
    }
}
