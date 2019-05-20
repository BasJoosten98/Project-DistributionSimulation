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

        private Cell cell;

        public CellForm(Cell c)
        {
            InitializeComponent();
            cell = c;
            initValues();
        }

        //Update Gui everytime index of combobox is changed
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGui();
        }

        //Initialize values in the GUI based on the info of the cell that was passed in the constructor.
        private void initValues()
        {
            lbRow.Text = cell.Index.Row.ToString();
            lbCol.Text = cell.Index.Column.ToString();
            nudDemand.Value = cell.Demand;
            checkCellBuilding();
            updateGui();           
        }

        // Check which building is selected in the combobox and update GUI accordingly.
        private void updateGui()
        {
            if (cbType.SelectedIndex == 1)
            {
                gbBuilding.Name = "Shop Info";
                gbBuilding.Enabled = true;
                // Might need to cast to shop first...If so then just make a shop variable 
                //nudStock.Value = cell.Location.Shop.Stock;
                //nudRestock.Value= cell.Location.Shop.Restock;
                //lbIDnum.Text = cell.Location.Shop.ID.ToString();
            }
            else if (cbType.SelectedIndex == 2)
            {
                gbBuilding.Name = "Warehouse Info";
                gbBuilding.Enabled = false;
                nudStock.Value = 0;
                nudRestock.Value = 0;
                lbIDnum.Text = "0";
            }
            else
            {
                gbBuilding.Name = "Building Info";
                //nudStock.Enabled = false;
                //nudRestock.Enabled = false;
                nudStock.Value = 0;
                nudRestock.Value = 0;
                lbIDnum.Text = "0";
                gbBuilding.Enabled = false;

            }
        }

        //Update ComboBox based on the type of building the cell has.
        private void checkCellBuilding()
        {
            /* if(cell.Location != null) {
                   if (cell.Location.Building.GetType() == typeof(Shop)) {
                       cbType.SelectedIndex = 1;
                   } else {
                       cbType.SelectedIndex = 2;
                   }
            } else {
                cbType.SelectedIndex = 0;
            }
            */
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            cell.Demand = Convert.ToInt32(nudDemand.Value);

            if (cbType.SelectedIndex == 1 )
            {
                int stock = Convert.ToInt32(nudStock.Value);
                int reStock = Convert.ToInt32(nudRestock.Value);
                // cell.Location.Building = new Shop (stock,restock)
            } else if (cbType.SelectedIndex == 2)
            {
                //cell.Location.Building = new Warehouse()
            }
        }
    }
}
