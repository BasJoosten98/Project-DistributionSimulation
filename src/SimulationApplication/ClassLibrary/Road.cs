using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public class Road
	{
        //Drawing fields
        public Color LineColor = Color.IndianRed;
        public Color StringColor = Color.White;
        public int LineWidth = 3;

        
        //other fields
        public Location Vertex1 { get; set; }
        public Location Vertex2 { get; set; }

        public int initialCost { get; set; }

        public Road(Location Vertex1, Location Vertex2)
        {

            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;

            this.initialCost = 1;
        }

        /// <summary>
        /// Changes the color of the text line and the length of the line
        /// </summary>
        public void ResetDrawFields()
        {
            LineColor = Color.IndianRed;
            StringColor = Color.White;
            LineWidth = 3;
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
