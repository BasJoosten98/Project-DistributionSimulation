using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StatisticsVehicle : Statistics
    {
        private Vehicle vehicle;
        private DeliveryStatus currentDeliveryStatus;
        private int totalDrivenTimeUnits;
        private int totalDeliveriesFinished;
        private int totalGivenDeliveries;
        private int totalDeliveryWaitTime;

        public Vehicle Vehicle { get { return vehicle; } }
        public DeliveryStatus CurrentDeliveryStatus { get { return currentDeliveryStatus; } }
        public int TotalGivenDeliveries { get { return totalGivenDeliveries; } }
        public int TotalFinishedDeliveries { get { return totalDeliveriesFinished; } }
        public int TotalDrivenTimeUnits { get { return totalDrivenTimeUnits; } }
        public int TotalNonDrivenTimeUnits { get { return Time - totalDrivenTimeUnits; } }
        public double DrivingTimePercentage { get { return (double)totalDrivenTimeUnits / Time; } }
        public double NonDrivingTimePercentage { get { return (double)TotalNonDrivenTimeUnits / Time; } }
        public int TotalDeliveryWaitTime { get { return totalDeliveryWaitTime; } }
        public double AverageDeliveryWaitTime { get { return (double)totalDeliveryWaitTime / TotalFinishedDeliveries; } }
        public StatisticsVehicle(int timeStamp, Vehicle me, DeliveryStatus deliveryStat, int drivenUnits, int totalDeliveriesFin, int totalDeliveriesGiven, int resTime)
            :base(timeStamp)
        {
            vehicle = me;
            currentDeliveryStatus = deliveryStat;
            totalDrivenTimeUnits = drivenUnits;
            totalDeliveriesFinished = totalDeliveriesFin;
            totalGivenDeliveries = totalDeliveriesGiven;
            totalDeliveryWaitTime = resTime;
        }
    }
}
