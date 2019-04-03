using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;

namespace ClassLibrary
{
    public class Location : Cell, IComparable
    {
        private static int locationID;
        //public const int CRADIUS = 25; // circle radius
        //public const int CDIAMETER = 50; // circle diameter might have something to do with the diameter of the cell someone should look into it

        public int LocationID { get; set; }
        public Building Building { get; set; }
        public int source_id { get; set; }
        public int min_cost { get; set; } // keeps the minimal cost of this vertex
        public bool permanent { get; set; } // used for deijsktra
        public bool visited { get; set; } // checks if it has been seen 

        //public int PositionX { get; }
        //public int PositionY { get; }

        public Location(int column, int row)
            : base(column, row)
        {
            LocationID = locationID++;
            //PositionX = x;
            //PositionY = y;

            this.min_cost = int.MaxValue;
            this.permanent = false;
            this.visited = false;

        }

        /// <summary>
        /// Returns center point of a Vertex.
        /// </summary>
        public Point Center { get { return new Point(base.Index.Column * Cell.CellSize + Cell.CellSize/2, base.Index.Row * Cell.CellSize + Cell.CellSize / 2); } }

        /// <summary>
        /// Return location point of a Vertex.
        /// </summary>
        public Point LocationPoint { get { return new Point(base.Index.Column * Cell.CellSize, base.Index.Row * Cell.CellSize); } }

        /// <summary>
        /// Returns default size of a Vertex.
        /// </summary>
        public Size _Size { get { return new Size(Cell.CellSize, Cell.CellSize); } }

        public int CompareTo(object obj)
        {
            return this.LocationID.CompareTo((obj as Location).LocationID);
        }

        public static int operator +(Location location, Road road)
        {
            return location.min_cost + road.initialCost;
        }
    }
}
