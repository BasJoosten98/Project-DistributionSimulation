using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public class Delivery
	{
        private DateTime startTime; //when truck started working on this delivery
        private DateTime createTime; //when the delivery object was made
        private DeliveryStatus status;
        private DijkstraRoute route;

        public DijkstraRoute Route { get { return route; } }
        public DeliveryStatus Status { get { return status; } }

        public Delivery(DijkstraRoute route)
        {
            route = Route;
            status = DeliveryStatus.NOTSTARTED;
        }

        public void startDelivery()
        {
            status = DeliveryStatus.DELIVERING;
        }
        public void doDelivery()
        {
            status = DeliveryStatus.COMINGBACK;

        }
        public void doFinish()
        {
            status = DeliveryStatus.FINISHED;
        }

	}
}
