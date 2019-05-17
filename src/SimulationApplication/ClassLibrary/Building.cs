using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public abstract class Building
	{
        public PictureBox picBox; //picturebox that contains a picture of Warehouse or Shop
        public Building(PictureBox PicBox)
        {
            picBox = PicBox;
        }
        public Building()
        {

        }
	}
}
