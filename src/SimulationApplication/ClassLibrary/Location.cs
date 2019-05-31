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
        //drawing fields
        public Color CircleColor = Color.Black;
        public Color CircleFillColor = Color.LightYellow;
        public Color StringColor = Color.Black;
        public int LocationID { get; set; }
        public Building Building { get; set; }
        public int source_id { get; set; }
        public int min_cost { get; set; } // keeps the minimal cost of this vertex
        public bool permanent { get; set; } // used for deijsktra
        public bool visited { get; set; } // checks if it has been seen 
        public int Radius { get; set; }

        public Location()
        { }

        public Location(int id, int column, int row) : this(id, column, row, 0)
        {
            //LocationID = locationID++;

            //this.min_cost = int.MaxValue;
            //this.permanent = false;
            //this.visited = false;
            //this.Radius = 3;
        }

        public Location(int id, int column, int row, int Radius) : base(column, row)
        {

            LocationID = id;
            this.min_cost = int.MaxValue;
            this.permanent = false;
            this.visited = false;
            this.Radius = Radius;
        }

        public  void ResetLocationId()
        {
            LocationID = 0;
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

        /// <summary>
        /// Compares the LocationID's of the given location
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return this.LocationID.CompareTo((obj as Location).LocationID);
        }

        public static int operator +(Location location, Road road)
        {
            return location.min_cost + road.InitialCost;
        }

        public override void ResetDrawFields()
        {
            base.ResetDrawFields();
            CircleColor = Color.Black;
            CircleFillColor = Color.LightYellow;
            StringColor = Color.Black;
        }
    }
}
