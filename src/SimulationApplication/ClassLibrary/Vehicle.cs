using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public class Vehicle
	{
        public static int capacity = 40;
        private static int idCounter = 0;
		private int id;
        private PictureBox picBox;
        List<Delivery> deliveryQueue;
        List<Delivery> finishedDeliveries;

        public PictureBox PicBox { get { return picBox; } }

        public Vehicle(PictureBox PicBox)
        {
            deliveryQueue = new List<Delivery>();
            finishedDeliveries = new List<Delivery>();
            id = idCounter;
            picBox = PicBox;
            idCounter++;
        }

        public void AddDeliveryToQueue(Delivery d)
        {
            deliveryQueue.Add(d);
        }

        public int lastDeliveryFinishDeltaTime()
        {
            int sum = 0;
            foreach(Delivery d in deliveryQueue)
            {
                sum += 2 * d.Route.RouteLenght - d.TotalTravelTime;
            }
            return sum;
        }

        public void nextTick()
        {
            if(deliveryQueue.Count != 0)
            {
                deliveryQueue[0].nextTick();
                calculateAndSetPosition();
                if (deliveryQueue[0].Route.RouteLenght == deliveryQueue[0].TotalTravelTime) //Delivery happenend!
                {
                    Shop temp = ((Shop)deliveryQueue[0].Route.EndPoint.Building);
                    temp.Stock += capacity;
                    Console.WriteLine("Shop" + temp.ID + " has been restocked by vehicle" + id + ", new stock = " + temp.Stock);                    
                }
                if (2*deliveryQueue[0].Route.RouteLenght == deliveryQueue[0].TotalTravelTime) //Delivery happenend!
                {
                    finishedDeliveries.Add(deliveryQueue[0]);
                    deliveryQueue.RemoveAt(0);
                }

            }
        }
        private void calculateAndSetPosition()
        {
            if(deliveryQueue.Count != 0)
            {
                Point position = deliveryQueue[0].CurrentRoad.onRoadLocation(deliveryQueue[0].DeltaTravelTime, deliveryQueue[0].NextLocation);
                picBox.Location = position;
            }
        }
	}
}
