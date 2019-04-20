using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class Vehicle
	{
        public static int capacity = 10;
        private static int idCounter = 0;
		private int id;
        List<Delivery> deliveryQueue;
        List<Delivery> finishedDeliveries;

        public Vehicle()
        {
            deliveryQueue = new List<Delivery>();
            finishedDeliveries = new List<Delivery>();
            id = idCounter;
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
                if(deliveryQueue[0].Route.RouteLenght == deliveryQueue[0].TotalTravelTime) //Delivery happenend!
                {
                    Shop temp = ((Shop)deliveryQueue[0].Route.EndPoint.Building);
                    temp.Stock += capacity;
                    Console.WriteLine("Shop" + temp.ID + " has been restocked by vehicle" + id + ", new stock = " + temp.Stock);
                    finishedDeliveries.Add(deliveryQueue[0]);
                    deliveryQueue.RemoveAt(0);
                }
                //update vehicle position on map
            }
        }
	}
}
