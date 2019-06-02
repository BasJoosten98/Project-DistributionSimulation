using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using ClassLibrary;

namespace MapLayout
{
    public partial class StatisticsForm : Form
    {

  
        List<Location> MyShops;
        List<int> MyShopsStock;


  
        public StatisticsForm( List<Location> selectedLocations)
        {
            InitializeComponent();

            //The locations are given at the begining, that is why the statistics button is enabled only after starting the simulation
            this.MyShops = selectedLocations;
          
            
            
            // (Location)MyShops = selectedLocations.Where(x => x.GetType() == typeof(Shop)).ToList();

        }

        public void Add(Location newLocation)
        {
            MyShops.Add(newLocation);
        }

    
        private void StatisticsForm_Load(object sender, EventArgs e)
        {

         // MyShopsStock = new List<int> {60,25,100};// used for test purposes


      
            ColumnSeries col = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>()
            ,
                LabelPoint = point => point.Y.ToString()
            };

            Axis ax = new Axis()
            //changing the separator values will change the strings of the Labels for the items that we put in
            { Separator = new Separator() { Step = 1, IsEnabled = false  } };
            ax.Labels = new List<string>();
            // adds the labels for the the shops in the form
            foreach (var x in MyShops)
            {
                ax.Labels.Add("Shop" + x.LocationID.ToString());
            }
            // adds the values for the column how high the values are 
            foreach (var x in 
                MyShops.Select(v => v.Building).Where(v => v is Shop).ToList())
            {
                col.Values.Add(((Shop)x).Stock);               
            }

            // puts the numbers on the chart
            cartesianChart1.Series.Add(col);
            //pus the bars in the chart
            cartesianChart1.AxisX.Add(ax);
            //adds the shops and seperates them
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            }
                );
        }

 
    }
}
