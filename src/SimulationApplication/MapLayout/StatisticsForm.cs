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

namespace MapLayout
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
         
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            List<string> MyShops = new List<string> {"Shop1","Shop2","Shop3" };
            List<int> MyShopsStock = new List<int> {60,25,100};

            ColumnSeries col = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>()
            ,
                LabelPoint = point => point.Y.ToString()
            };

            Axis ax = new Axis()
            { Separator = new Separator() { Step = 1, IsEnabled = false  } };
            ax.Labels = new List<string>();
            
            foreach (var x in MyShops)
            {
                ax.Labels.Add(x.ToString());
            }
            foreach (var x in MyShopsStock)
            {
                col.Values.Add(x);               
            }


            cartesianChart1.Series.Add(col);
            cartesianChart1.AxisX.Add(ax);
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            }
                );
        }
    }
}
