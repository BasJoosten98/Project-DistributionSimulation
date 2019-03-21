using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class Road
	{
        public Location Vertex1 { get; set; }
        public Location Vertex2 { get; set; }

        public int initialCost { get; set; }

        public Road(Location Vertex1, Location Vertex2)
        {

            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;

            this.initialCost = 1;
        }

        public Location this[int index]
        {

            get
            {

                switch (index)
                {

                    case 0: return Vertex1;
                    case 1: return Vertex2;
                }

                throw new IndexOutOfRangeException();
            }
        }
    }
}
