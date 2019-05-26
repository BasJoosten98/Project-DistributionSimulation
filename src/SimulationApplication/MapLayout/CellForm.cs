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
        private Cell cell;

        public CellForm(Location l, Cell c)
        {
            InitializeComponent();
            gbBInfo.Hide();
            gbWarehouse.Hide();
            location = l;
            cell = c;
            initValues();
        }

        //Initialize values in the GUI based on the info of the CELL that was passed in the constructor.
        private void initValues()
        {
            lbRow.Text = cell.Index.Row.ToString();
            lbCol.Text = cell.Index.Column.ToString();
            lbDemand.Text = cell.Demand.ToString();
            tbGrowth.Text = cell.DemandGrow.ToString();

            checkCell();
        }

        //Checks if the location passed in the constructor is not null (meaning the cell has a location). 
        //if so, detect whether it is a shop or warehouse and update gui accordingly.
        //if not, then cell has no location. apply minor gui changes.
        private void checkCell()
        { 
            if (location != null)
            {
                if (location.Building != null)
                {
                    if (location.Building.GetType() == typeof(Shop))
                    {
                        Shop s = (Shop)location.Building;
                        lbBuilding.Text = "Shop";
                        tbStock.Text = s.Stock.ToString();
                        tbReStock.Text = s.RestockAmount.ToString();
                        lbIDnum.Text = s.ID.ToString();
                        gbBInfo.Show();
                    }
                    else
                    {
                        Warehouse w = (Warehouse)location.Building;
                        lbBuilding.Text = "Warehouse";
                        tbVehicles.Text = w.TotalVehiclesAtStart.ToString();
                        gbWarehouse.Show();
                    }
                }
                else
                {
                    lbBuilding.Text = "None";
                    gbBInfo.Show();
                    gbBInfo.Enabled = false;
                }
            }
            else
            {
                lbBuilding.Text = "None";
                gbBInfo.Show();
                gbBInfo.Enabled = false;
                lbLocation.Text = "Position";
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            int growth = Convert.ToInt32(tbGrowth.Text);
            if (growth >= 0)
            {
                cell.SetDemandGrow(growth);
            }
            else
            {
                MessageBox.Show("Demand cannot be less than 0");
            }


            switch (lbBuilding.Text)
            {
                case "Shop":
                    Shop s = (Shop)location.Building;
                    int stock = Convert.ToInt32(tbStock.Text);
                    int reStock = Convert.ToInt32(tbReStock.Text);
                    if (stock >= 0 && reStock >= 0)
                    {
                        s.Stock = stock;
                        s.RestockAmount = reStock;
                    } else
                    {
                        MessageBox.Show("Neither stock or restock can be less than 0");
                    }
                    break;
                case "Warehouse":
                    setVehicles(Convert.ToInt32(tbVehicles.Text));
                    break;
            }
        }

        //Some logic that add or remove a certain amount of vehicles in the list based on what is in the textbox 
        //and how many vehicles are in the list.
        private void setVehicles(int amount)
        {
            Warehouse w = (Warehouse)location.Building;
            //Point ImagePosition = new Point((location.Index.Column * Cell.CellSize) + 4, (location.Index.Row * Cell.CellSize) + 4);
            //int listSize = w.Vehicles.Count;
            if (amount > 0)
            {
                w.TotalVehiclesAtStart = amount;
            }
            else
            {
                MessageBox.Show("Total Vehicles must be greater than 0");
            }


        }

        public void disableFields()
        {
            gbBInfo.Enabled = false;
            gbWarehouse.Enabled = false;
            tbGrowth.Enabled = false;
        }

        //Copied vehicle picturebox creation code from form1 createNewVehicle Method. Simple to add a picturebox to vehicle constructor.
        //private Vehicle genNewVehicle(Point ImagePosition)
        //{
        //    PictureBox vehiclePicBox = new PictureBox();
        //    vehiclePicBox.Image = Properties.Resources.vehicleIcon;
        //    vehiclePicBox.Location = ImagePosition;
        //    vehiclePicBox.Size = new Size(Cell.CellSize / 2, Cell.CellSize / 2);
        //    vehiclePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        //    //splitContainer1.Panel1.Controls.Add(vehiclePicBox); uh not sure if i need this.
        //    vehiclePicBox.BringToFront();
        //    return new Vehicle(vehiclePicBox);
        //}
    }

}
