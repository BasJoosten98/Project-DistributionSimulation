using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace MapLayout
{
    public partial class CellForm : Form
    {

        private Location location;

        public CellForm(Location l)
        {
            InitializeComponent();
            location = l;
            initValues();
        }

        //Update Gui everytime index of combobox is changed
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGui();
        }

        //Initialize values in the GUI based on the info of the location that was passed in the constructor.
        private void initValues()
        {
            lbRow.Text = location.Index.Row.ToString();
            lbCol.Text = location.Index.Column.ToString();
            nudDemand.Value = location.Demand;
            checkCellBuilding();
            updateGui();
        }

        // Check which building is selected in the combobox and update GUI accordingly.
        private void updateGui()
        {
            if (cbType.SelectedIndex == 1)
            {

                gbBInfo.Name = "Shop Info";
                gbBInfo.Enabled = true;

                if(location.Building is Shop)
                {
                    Shop s = (Shop)location.Building;

                    //Building does not have any of these values..figure out solution
                    nudStock.Value = s.Stock;
                    nudRestock.Value = s.RestockAmount;
                    lbIDnum.Text = s.ID.ToString();
                }
                else
                {
                    nudStock.Value = 0;
                    nudRestock.Value = 0;
                    lbIDnum.Text = "0";
                }

            }
            else if (cbType.SelectedIndex == 2)
            {
                gbBInfo.Name = "Warehouse Info";
                gbBInfo.Enabled = false;
                nudStock.Value = 0;
                nudRestock.Value = 0;
                lbIDnum.Text = "0";
            }
            else
            {
                gbBInfo.Name = "Building Info";
                //nudStock.Enabled = false;
                //nudRestock.Enabled = false;
                nudStock.Value = 0;
                nudRestock.Value = 0;
                lbIDnum.Text = "0";
                gbBInfo.Enabled = false;

            }
        }

        //Update ComboBox based on the type of building the cell has.
        private void checkCellBuilding()
        {
            if (location.Building != null)
            {
                if (location.Building.GetType() == typeof(Shop))
                {
                    cbType.SelectedIndex = 1;
                }
                else
                {
                    cbType.SelectedIndex = 2;
                }
            }
            else
            {
                cbType.SelectedIndex = 0;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            location.SetDemandGrow(Convert.ToInt32(nudDemand.Value));
            PictureBox p;

            if (cbType.SelectedIndex == 1)
            {
                int stock = Convert.ToInt32(nudStock.Value);
                int reStock = Convert.ToInt32(nudRestock.Value);
                p = genPicturebox(Type.Shop);
                location.Building = new Shop(p, stock, reStock);
            }
            else if (cbType.SelectedIndex == 2)
            {
                p = genPicturebox(Type.Warehouse);
                location.Building = new Warehouse(p);
            } else
            {
                p = genPicturebox(Type.None);
            }
        }

        //Generate a picturebox to put in the shop/warehouse constructor.
        private PictureBox genPicturebox(Type type)
        {
            PictureBox picBox = new PictureBox();
            Point ImagePosition = new Point((location.Index.Column * Cell.CellSize) + 4, (location.Index.Row * Cell.CellSize) + 4);
            picBox.Location = ImagePosition;
            picBox.Size = new Size(Cell.CellSize - 1, Cell.CellSize - 1);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //Not sure how to add the mouse click yet
            //picBox.MouseClick += mapPictureBox_MouseClick;
            //picBox.MouseEnter += mapPictureBox_MouseEnter;

            if (type == Type.Shop)
            {
                picBox.Image = Properties.Resources.shopIcon;
                location.Building = new Shop(picBox, 500, 450);
                //lbLocationLog.Text = "Location #: " + id + " has been set to a Shop";
                Console.WriteLine("Shop has been added to location" + location.LocationID);
            }
            else if (type == Type.Warehouse)
            {
                picBox.Image = Properties.Resources.warehouseIcon;
                location.Building = new Warehouse(picBox);
                //Not sure how to add the vehicles yet.
                //((Warehouse)location.Building).AddVehicle(createNewVehicle(ImagePosition));
                //((Warehouse)location.Building).AddVehicle(createNewVehicle(ImagePosition));
                //lbLocationLog.Text = "Location #: " + id + " has been set to a WareHouse";
                Console.WriteLine("Warehouse has been added to location" + location.LocationID);
            } else
            {

            }
            return picBox;  
        }

        enum Type
        {
            Shop,
            Warehouse,
            None
        }
    }
}
