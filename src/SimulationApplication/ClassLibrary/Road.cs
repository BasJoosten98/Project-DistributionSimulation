using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void DrawLine(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(new Pen(Color.IndianRed, 3), Vertex1.Center, Vertex2.Center);
        }
        public void DrawString(Graphics g, Font font)
        {
            g.DrawString(initialCost.ToString(), font, new SolidBrush(Color.White), 0.5f * (Vertex1.Center.X + Vertex2.Center.X) - font.Size, 0.5f * (Vertex1.Center.Y + Vertex2.Center.Y) - font.Size / 2);
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
