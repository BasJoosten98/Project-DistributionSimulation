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
        public delegate void ReAssignMaxDemandHandler();
        public event ReAssignMaxDemandHandler MapInNeedOfReAssignmentOfMaximum;

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
            tbMax.Text = Cell.MaxAllowedDemand.ToString();
            if (location != null)
            {
                tbRaduis.Text = location.Radius.ToString();
            }

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
                        tbCapacity.Text = Vehicle.capacity.ToString();
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
                tbRaduis.Enabled = false;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                int growth = Convert.ToInt32(tbGrowth.Text);
                int max = Convert.ToInt32(tbMax.Text);
                if (growth >= 0 && max >= 0)
                {
                    cell.SetDemandGrow(growth);
                    Cell.MaxAllowedDemand = max;
                    MapInNeedOfReAssignmentOfMaximum?.Invoke();
                    if (location != null)
                    {
                        int radius = Convert.ToInt32(tbRaduis.Text);

                        if (radius >= 0)
                            location.Radius = radius;
                        else
                            MessageBox.Show("Radius cannot be less than 0");
                    }
                }
                else
                {
                    MessageBox.Show("Neither Growth or Max can be less than 0");
                }
            } catch (FormatException)
            {
                MessageBox.Show("Please only use numbers.");
            }
            


            switch (lbBuilding.Text)
            {
                case "Shop":
                    Shop s = (Shop)location.Building;
                    int stock = Convert.ToInt32(tbStock.Text);
                    int reStock = Convert.ToInt32(tbReStock.Text);
                    if (stock >= 0 && reStock >= 0)
                    {
                        s.SetStockAndBackup( stock);
                        s.RestockAmount = reStock;
                    } else
                    {
                        MessageBox.Show("Neither stock or restock can be less than 0");
                    }
                    break;
                case "Warehouse":
                    setVehicles(Convert.ToInt32(tbVehicles.Text), Convert.ToInt32(tbCapacity.Text));
                    break;
            }
        }

        //Some logic that add or remove a certain amount of vehicles in the list based on what is in the textbox 
        //and how many vehicles are in the list.
        private void setVehicles(int amount, int capacity)
        {
            Warehouse w = (Warehouse)location.Building;
            //Point ImagePosition = new Point((location.Index.Column * Cell.CellSize) + 4, (location.Index.Row * Cell.CellSize) + 4);
            //int listSize = w.Vehicles.Count;
            if (amount > 0  && capacity >= 0)
            {
                w.TotalVehiclesAtStart = amount;
                Vehicle.capacity = capacity;
            }
            else
            {
                MessageBox.Show("Total Vehicles & Capacity must be greater than 0");
            }


        }

        public void disableFields()
        {
            gbBInfo.Enabled = false;
            gbWarehouse.Enabled = false;
            gbInfo.Enabled = false;
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
