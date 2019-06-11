using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StatisticsWarehouse : Statistics
    {
        private List<StatisticsVehicle> vehicles;
        private Warehouse warehouse;


        public List<StatisticsVehicle> Vehicles { get { return vehicles; } }
        public Warehouse Warehouse { get { return warehouse; } } 
        public int TotalGivenDeliveries
        {
            get
            {
                int sum = 0;
                foreach(StatisticsVehicle v in vehicles)
                {
                    sum += v.TotalGivenDeliveries;
                }
                return sum;
            }
        }
        public int TotalFinishedDeliveries
        {
            get
            {
                int sum = 0;
                foreach (StatisticsVehicle v in vehicles)
                {
                    sum += v.TotalFinishedDeliveries;
                }
                return sum;
            }
        }


        public double AverageDeliveryWaitingTime
        {
            get
            {
                double sum = 0; int counter = 0;
                foreach(StatisticsVehicle v in vehicles)
                {
                    sum += v.AverageDeliveryWaitTime; counter++;
                }
                return sum/counter;
            }
        }

        public double VehicleBeingUsedTimePercentage
        {
            get
            {
                double sum = 0; int counter = 0;
                foreach (StatisticsVehicle v in vehicles)
                {
                    sum += v.DrivingTimePercentage; counter++;
                }
                return sum / counter;
            }
        }

        public StatisticsWarehouse(int timeStamp, Warehouse me ,List<StatisticsVehicle> vehiclesStat)
            :base(timeStamp)
        {
            vehicles = vehiclesStat;
            warehouse = me;

            if (true) //testing
            {
                Console.WriteLine("current id: " + ID);
                Console.WriteLine("TGD: " + TotalGivenDeliveries + " TFD: " + TotalFinishedDeliveries);
                Console.WriteLine("ADWT: " + AverageDeliveryWaitingTime + " VBUTP: " + VehicleBeingUsedTimePercentage);
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }
    }

}
