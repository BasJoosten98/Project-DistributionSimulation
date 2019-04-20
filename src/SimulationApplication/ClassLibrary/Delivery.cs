using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class Delivery
	{
        private DateTime startTime; //when truck started working on this delivery
        private DateTime deliveryTime;
        private DateTime endTime;
        private List<Road> route;
        private bool goingBack;

        public List<Road> Route { get { return route; } }
        public bool GoingBack { get { return goingBack; } }

        public Delivery(List<Road> Route)
        {
            route = Route;
            goingBack = false;
        }

        public void doDelivery()
        {
            goingBack = true;
            //set deliveryTime

        }
        public void doFinish()
        {
            //set endTime
        }

	}
}
