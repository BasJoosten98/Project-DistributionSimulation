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
        private static int idCounter = 0;
        public int id;
        public Color LineColor = Color.Black;
        public Color StringColor = Color.Yellow;
        public int LineWidth = 3;

        //other fields
        public Location Vertex1 { get; set; }
        public Location Vertex2 { get; set; }

        public int InitialCost { get; set; }

        public Road(Location Vertex1, Location Vertex2, int initialCost = 1)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            id = idCounter;
            idCounter++;
            InitialCost = initialCost;
        }

        /// <summary>
        /// Changes the color of the text line and the length of the line
        /// </summary>
        public void ResetDrawFields()
        {
            LineColor = Color.Black;
            StringColor = Color.Yellow;
            LineWidth = 3;
        }

        public Point onRoadLocation(int deltaTime, Location to)
        {
            Location from;
            if(to == Vertex1) { from = Vertex2; }
            else { from = Vertex1; }
            //if(deltaTime == 0)
            //{
            //    return from.Center;
            //}
            //if (deltaTime == initialCost)
            //{
            //    return to.Center;
            //}
            //return new Point((from.Center.X + to.Center.X) / 2, (from.Center.Y + to.Center.Y) / 2);
            return new Point(from.Center.X + deltaTime * (to.Center.X - from.Center.X) / InitialCost, from.Center.Y + deltaTime * (to.Center.Y - from.Center.Y)/InitialCost);
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

        public void Save(int mapId)
        {
            Location source = Vertex1;
            Location destination = Vertex2;
            string sql = "INSERT INTO ROADS (Location1MapId, Location1RowIndex, Location1ColumnIndex, Location2MapId, Location2RowIndex, Location2ColumnIndex, InitialCost)" +
                         $"VALUES ('{mapId}', '{source.Index.Row}', '{source.Index.Column}', '{mapId}', '{destination.Index.Row}', '{destination.Index.Column}', '{InitialCost}');";
            DataBase.ExecuteNonQuery(sql);
        }
    }
}
