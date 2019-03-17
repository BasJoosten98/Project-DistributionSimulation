using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
	public class Location
	{
        private static int locationID;
		public int LocationID { get; set; }
		public int Demand;
        public Building Building { get; set; }


        public int PositionX { get; }
        public int PositionY { get; }

        public Location(int x, int y)
        {
            LocationID = ++locationID;
            PositionX = x;
            PositionY = y;
        }

       
        

        
	}
}
