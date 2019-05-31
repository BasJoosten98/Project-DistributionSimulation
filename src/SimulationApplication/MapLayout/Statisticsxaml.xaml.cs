using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class BasicColumn : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }



        public BasicColumn()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            Labels = new[] { "Shop1", "Shop2", "Shop3", "Shop4" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

    }
}