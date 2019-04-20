using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class Vehicle
	{
		public static int capacity;
        private static int idCounter = 0;
		private int id;
        List<Delivery> deliveryQueue;

        public Vehicle()
        {
            deliveryQueue = new List<Delivery>();
            id = idCounter;
            idCounter++;
        }

        public void AddDeliveryToQueue(Delivery d)
        {
            deliveryQueue.Add(d);
        }

	}
}
