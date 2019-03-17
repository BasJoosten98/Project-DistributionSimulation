using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulationApplication.ClassLibrary;
namespace MapLayout
{
    public partial class Form1 : Form
    {
        private Map map;
        public Form1()
        {
            InitializeComponent();
            map = new Map();
            AddLocations();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawMap();  
        }

       


        private void AddLocations()
        {
            
            map.AddLocation(new Location(20, 20));
            map.AddLocation(new Location(90, 180));
            map.AddLocation(new Location(70, 300));
            map.AddLocation(new Location(300, 20));
            map.AddLocation(new Location(140, 400));
            map.AddLocation(new Location(370, 300));
            map.AddLocation(new Location(380, 40));
            
        }



        public void DrawMap()
        {
            //TODO: A more dynamic way of drawing the map is preferred, but this is a draft for now.
            
            Graphics g = this.CreateGraphics();
            
            Pen p = new Pen(Brushes.Black, 8);
            Pen p2 = new Pen(Brushes.Red, 15);
            for (int i = 0; i < map.Locations.Count; i++)
            {
                
                
                if (i >= 1)
                {
                    g.DrawEllipse(p, map.Locations[i].PositionX, map.Locations[i].PositionY, 10, 10);
                    g.DrawLine(p, map.Locations[i].PositionX, map.Locations[i].PositionY, map.Locations[i - 1].PositionX, map.Locations[i - 1].PositionY);
                }
                if (i >= 2)
                {
                    g.DrawLine(p, map.Locations[i].PositionX, map.Locations[i].PositionY, map.Locations[i - 2].PositionX, map.Locations[i - 2].PositionY);
                }
                

                if (map.Locations[i].Building != null)
                {
                    g.DrawEllipse(p2, map.Locations[i].PositionX, map.Locations[i].PositionY, 10, 10);
                }
                else if (map.Locations[i].Building == null)
                {
                    g.DrawEllipse(p, map.Locations[i].PositionX, map.Locations[i].PositionY, 10, 10);
                }


            }
        }

        private void btnSetBuilding_Click(object sender, EventArgs e)
        {
            int locationID = Convert.ToInt32(tbLocationID.Text);
            map.PlaceBuilding(locationID);
            this.Invalidate();
            DrawMap();
            
        }
    }
}
