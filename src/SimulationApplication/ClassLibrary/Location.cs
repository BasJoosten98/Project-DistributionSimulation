using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
    public class Location
    {
        private static int locationID;
        public int LocationID { get; set; }
        public Building Building { get; set; }


        public int PositionX { get; }
        public int PositionY { get; }

        public Location(int x, int y)
        {
            LocationID = ++locationID;
            PositionX = x;
            PositionY = y;
        }

        //our own variables
        //public Building building {get;set;}

        //public int id { get; set; }
        //public int source_id { get; set; }
        //public int min_cost { get; set; }

        //public bool permanent { get; set; }
        //public bool visited { get; set; }


        //public int x { get; set; }
        //public int y { get; set; }

        //public Location(int id)
        //{

        //    this.id = id;
        //    this.min_cost = int.MaxValue;
        //    this.permanent = false;
        //    this.visited = false;
        //}

        //public int CompareTo(object obj)
        //{
        //    return this.id.CompareTo((obj as Vertex).id);
        //}

        //public static int operator +(Vertex a, Edge b)
        //{
        //    return a.min_cost + b.cost;
        //}

        ///// <summary>
        ///// Returns center point of a Vertex.
        ///// </summary>
        //public Point Center { get { return new Point(x * mainForm.CDIAMETER + mainForm.CRADIUS, y * mainForm.CDIAMETER + mainForm.CRADIUS); } }

        ///// <summary>
        ///// Return location point of a Vertex.
        ///// </summary>
        //public Point Location { get { return new Point(x * mainForm.CDIAMETER, y * mainForm.CDIAMETER); } }

        ///// <summary>
        ///// Returns default size of a Vertex.
        ///// </summary>
        //public Size _Size { get { return new Size(mainForm.CDIAMETER, mainForm.CDIAMETER); } }
    }





}
