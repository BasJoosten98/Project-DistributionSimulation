using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
	public class Road
	{
        // Fields for storage
        public Map Map { get; set; }
        public Location Location1 { get; set; }
        public Location Location2 { get; set; }
        public int InitialCost { get; set; }

        // Foreign Key
        public int MapId { get; set; }
        public int Location1Id { get; set; }
        public int Location2Id { get; set; }

        //Drawing fields
        [NotMapped]
        private static int idCounter = 0;
        [NotMapped]
        public int id;
        [NotMapped]
        public Color LineColor = Color.Black;
        [NotMapped]
        public Color StringColor = Color.Yellow;
        [NotMapped]
        public int LineWidth = 3;

        public Road(Location location1, Location location2)
        {
            Location1 = location1;
            Location2 = location2;
            id = idCounter;
            idCounter++;
            InitialCost = 1;
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
            if(to == Location1) { from = Location2; }
            else { from = Location1; }
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

                    case 0: return Location1;
                    case 1: return Location2;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
}
