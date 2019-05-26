using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
	public abstract class Building
    {
        public int Id { get; set; }

        [NotMapped]
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
