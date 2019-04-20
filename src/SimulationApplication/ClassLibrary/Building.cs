using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public abstract class Building
	{
        public PictureBox picBox;
        public Building(PictureBox PicBox)
        {
            picBox = PicBox;
        }
        public Building()
        {

        }
	}
}
