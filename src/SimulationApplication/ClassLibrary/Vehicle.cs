using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public class Vehicle
	{
        public static int capacity = 150;
        private static int idCounter = 0;
		private int id;
        public PictureBox picBox;
        List<Delivery> deliveryQueue; //list of deliveries that this vehicle needs to do
        List<Delivery> finishedDeliveries; //list of deliveries that this vehicle has finished

        public PictureBox PicBox { get { return picBox; } }

        public Vehicle(PictureBox PicBox)
        {
            deliveryQueue = new List<Delivery>();
            finishedDeliveries = new List<Delivery>();
            id = idCounter;
            picBox = PicBox;
            idCounter++;
        }

        /// <summary>
        /// Add given delivery to the deliveries queue
        /// </summary>
        /// <param name="d"></param>
        public void AddDeliveryToQueue(Delivery d)
        {
            deliveryQueue.Add(d);
        }

        /// <summary>
        /// Calculates when this vehicle can start deliverying a new delivery
        /// </summary>
        /// <returns></returns>
        public int lastDeliveryFinishDeltaTime()
        {
            int sum = 0;
            foreach(Delivery d in deliveryQueue)
            {
                sum += 2 * d.Route.RouteLenght - d.TotalTravelTime;
            }
            return sum;
        }

        public void NextTick()
        {
            if(deliveryQueue.Count != 0) //Check if this vehicle has any delivery
            {
                deliveryQueue[0].NextTick(); //Update delivery
                calculateAndSetPosition(); //Set vehicle position
                if (deliveryQueue[0].Route.RouteLenght == deliveryQueue[0].TotalTravelTime) //Delivery at shop happenend!
                {
                    Shop temp = ((Shop)deliveryQueue[0].Route.EndPoint.Building);
                    temp.Stock += capacity;
                    Console.WriteLine("Shop" + temp.ID + " has been restocked by vehicle" + id + ", new stock = " + temp.Stock);                    
                }
                if (2*deliveryQueue[0].Route.RouteLenght == deliveryQueue[0].TotalTravelTime) //Returned to warehouse
                {
                    finishedDeliveries.Add(deliveryQueue[0]);
                    deliveryQueue.RemoveAt(0);
                }

            }
        }
        /// <summary>
        /// Update vehicle position based on delivery position
        /// </summary>
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
