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
        public static Image shopIcon;
        public static Image WarehouseIcon;
        public Building(Point ImagePosition)
        {
            picBox = new PictureBox();
            picBox.Location = ImagePosition;
            picBox.Size = new Size(Cell.CellSize - 1, Cell.CellSize - 1);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //picBox.BringToFront(); Must be on Form1 in order to work!!
        }
	}
}
