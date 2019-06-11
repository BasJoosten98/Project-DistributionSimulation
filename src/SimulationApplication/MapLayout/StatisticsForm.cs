﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using ClassLibrary;
using System.Windows.Media;


namespace MapLayout
{
    public partial class StatisticsForm : Form
    {


        List<Location> MyShops;
        List<Location> MyWarehouses;
        List<int> MyShopsStock;
        Form1 parentForm;
        private Map map;
        int numberOfVehiclesInTotal;

        public StatisticsForm(List<Location> shops, List<Location> MyWarehouses, Form1 form, Map map)
        {

            InitializeComponent();
            this.parentForm = form;
            parentForm.Timer.Tick += new EventHandler(Timer_Tick);
            numberOfVehiclesInTotal = 0;
            //The locations are given at the begining, that is why the statistics button is enabled only after starting the simulation
            this.MyShops = shops;
            this.MyWarehouses = MyWarehouses;
            this.map = map;
            //set the total number of vehicles
     
            MyWarehouses.ForEach(warehouse => numberOfVehiclesInTotal += ((Warehouse)warehouse.Building).Vehicles.Count);

            InitializeBarChart();
         //   InitializeLineChart();
            InitializePieChart();

        }
        ColumnSeries col = new ColumnSeries()
        {
            Title = "Stock",
            DataLabels = true,
            Values = new ChartValues<int>(),
            LabelPoint = point => point.Y.ToString()
        };
        Axis ax = new Axis()
        //changing the separator values will change the strings of the Labels for the items that we put in
        {
            Title = "Shops",
            Separator = new Separator() { Step = 1, IsEnabled = false }
        };

        ChartValues<int> myShopValues;
        public void InitializeBarChart()
        {
            myShopValues = new ChartValues<int>();

            ColumnSeries col = new ColumnSeries()
            {
                Title = "Stock",
                DataLabels = true,
                Values = myShopValues,
                LabelPoint = point => point.Y.ToString()
            };
            Axis ax = new Axis()
            //changing the separator values will change the strings of the Labels for the items that we put in
            {
                Title = "Shops",
                Separator = new Separator() { Step = 1, IsEnabled = false }
            };
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
            myChart2.Series.Add(col);
            //pus the bars in the chart
            myChart2.AxisX.Add(ax);
            //adds the shops and seperates them
            myChart2.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            }
                );

            // myChart2.Series[0].Values[2];

        }

        // Will need this to change the Movement of the piechart 
        List<ChartValues<int>> myPieChartsValues;
        List<Statistics> myWarehouseStatistics;
        public void InitializePieChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            myPieChartsValues = new List<ChartValues<int>>();

           // List<ChartValues<double>> myCharts = new List<ChartValues<double>>();




            pieChart1.Series = new SeriesCollection
            {

            };



            //put all the titles in a list so I can add them in the pieChart chart
            List<string> warehouseTitles = new List<string>();
            foreach (var warehouse in MyWarehouses)
            {
                warehouseTitles.Add("Warehouse" + warehouse.LocationID.ToString());
            }

            myWarehouseStatistics = map.Statistics.Where(x => x is StatisticsWarehouse).ToList();





            foreach (var warehouse in MyWarehouses)
            {
                int sum = 0;
                foreach (var warStatistic in map.Statistics.Where(x => x is StatisticsWarehouse))
                {
                    if (((StatisticsWarehouse)warStatistic).Warehouse == warehouse.Building)
                    {
                        ((StatisticsWarehouse)warStatistic).Vehicles.ForEach(vehicle => sum += vehicle.TotalDrivenTimeUnits);                      
                    }
                }
                myPieChartsValues.Add(new ChartValues<int> { sum });
            }

            // not sure what this does, should make sure that this represents the statistics of all the vehicles that have given deliveries.
            //foreach (Warehouse warehouse in MyWarehouses.Select(v => v.Building).Where(v => v is Warehouse).ToList())
            //{
            //    int sum = 0;
            //    warehouse.MakeStatistics(count).Vehicles.ForEach(vehicle => sum += vehicle.TotalGivenDeliveries);
            //    count++;
            //    myPieChartsValues.Add(new ChartValues<int> { sum });

            //}

            // add a new pieChartSeries for each warehouse.
            for (int i = 0; i < MyWarehouses.Count; i++)
            {
                pieChart1.Series.Add
                    (
                        new PieSeries()
                        {

                            Title = warehouseTitles[i],
                            Values = myPieChartsValues[i],
                            DataLabels = true,
                            LabelPoint = labelPoint
                        }
                    );
            }

            //.ForEach(x => ((StatisticsWarehouse)x).Vehicles.
            //ForEach(x=>x.TotalFinishedDeliveries) );

            // statistics that are of type warehouse

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }


        

        


        /// <summary>
        /// Used to Refresh the selectedLocations recommended to be called at each tick of the form.
        /// </summary>
        /// <param name="selectedLocations"></param>
        public void Add(List<Location> selectedLocations)
        {
            this.MyShops = selectedLocations;
        }


        private void StatisticsForm_Load(object sender, EventArgs e)
        {
         
        }

        int count = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {

            // Removing and adding the new values of  the shop barChart

            foreach (var value in myShopValues)
                myShopValues.Remove(value);

            foreach (var shop in MyShops.Select(v => v.Building).Where(v => v is Shop).ToList())
            {
                myShopValues.Add(((Shop)shop).Stock);
            }

            //Removing and adding the new values for the PieChartWarehouses.

            foreach (var value in myPieChartsValues.ToList())
            {
                myPieChartsValues.Remove(value);
            }

            //foreach (Warehouse warehouse in MyWarehouses.Select(v => v.Building).Where(v => v is Warehouse).ToList())
            //{
            //    int sum = 0;
            //    warehouse.MakeStatistics(count).Vehicles.ForEach(vehicle => sum += vehicle.TotalDrivenTimeUnits);
            //    count++;
            //    myPieChartsValues.Add(new ChartValues<int> { sum });

            //}

            foreach (var warehouse in MyWarehouses)
            {
                int sum = 0;
                foreach (var warStatistic in map.Statistics.Where(x => x is StatisticsWarehouse))
                {
                    if (((StatisticsWarehouse)warStatistic).Warehouse == warehouse.Building)
                    {
                        ((StatisticsWarehouse)warStatistic).Vehicles.ForEach(vehicle => sum += vehicle.TotalGivenDeliveries);
                    }
                }
                myPieChartsValues.Add(new ChartValues<int> { sum });
            }

            //Trying to update all the labels

            double AverageDeliveryWaitTime = 0;
            double DrivingTimePercentage = 0;
            double NonDrivingTimePercentage = 0;
            double TotalDeliveryWaitTime = 0;
            double TotalDrivenTimeUnits = 0;
            double TotalFinishedDeliveries = 0;
            double TotalGivenDelivers = 0;
            double TotalNonDrivenTimeUnits = 0;

            foreach (var warehouse in MyWarehouses)
            {
                
                foreach (var warStatistic in map.Statistics.Where(x => x is StatisticsWarehouse))
                {
                    ((StatisticsWarehouse)warStatistic).Vehicles.ForEach(vehicle => 
                    {
                       

                        AverageDeliveryWaitTime += vehicle.AverageDeliveryWaitTime;
                     //   DrivingTimePercentage += vehicle.DrivingTimePercentage;
                        NonDrivingTimePercentage += vehicle.NonDrivingTimePercentage;
                        TotalDeliveryWaitTime += vehicle.TotalDeliveryWaitTime;
                        TotalDrivenTimeUnits += vehicle.TotalDrivenTimeUnits;
                        TotalFinishedDeliveries += vehicle.TotalFinishedDeliveries;
                        TotalGivenDelivers += vehicle.TotalGivenDeliveries;
                        TotalNonDrivenTimeUnits += vehicle.TotalGivenDeliveries;
                    });
                }
             
            }

            lbAverageDeliveryWaitTime.Text = (AverageDeliveryWaitTime / numberOfVehiclesInTotal).ToString();
          //  lbDrivingTimePercentage.Text = (DrivingTimePercentage / numberOfVehiclesInTotal).ToString();
            lbNonDrivingTimePercentage.Text = (NonDrivingTimePercentage / numberOfVehiclesInTotal).ToString();
            lbTotalDeliveryWaitTime.Text = (TotalNonDrivenTimeUnits / numberOfVehiclesInTotal).ToString();
            lbTotalDrivenTimeUnits.Text = (TotalDrivenTimeUnits / numberOfVehiclesInTotal).ToString();
            lbTotalFinishedDeliveries.Text = (TotalFinishedDeliveries / numberOfVehiclesInTotal).ToString();
            lbTotalGivenDeliveries.Text = (TotalGivenDelivers / numberOfVehiclesInTotal).ToString();
            lbTotalNonDrivenTimeUnits.Text = (TotalNonDrivenTimeUnits / numberOfVehiclesInTotal).ToString();

        }
    }
}