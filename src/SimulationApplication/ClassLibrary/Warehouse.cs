using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
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
