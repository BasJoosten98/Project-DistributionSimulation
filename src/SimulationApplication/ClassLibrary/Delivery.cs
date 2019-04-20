using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ClassLibrary
{
	public class Delivery
	{
        private DateTime startTime; //when truck started working on this delivery
        private DateTime createTime; //when the delivery object was made
        private DeliveryStatus status;
        private DijkstraRoute route;
        private int totalTravelTime;
        private Road previousColoredRoad = null;

        public DijkstraRoute Route { get { return route; } }
        public DeliveryStatus Status { get { return status; } }
        public int TotalTravelTime { get { return totalTravelTime; } }

        public Delivery(DijkstraRoute dRoute)
        {
            if(!(dRoute.EndPoint.Building is Shop)) { throw new Exception("Building needs to be a shop!"); }
            route = dRoute;
            status = DeliveryStatus.NOTSTARTED;
            totalTravelTime = 0;
        }

        public void nextTick()
        {
            totalTravelTime++;
            if(totalTravelTime == route.RouteLenght)
            {
                status = DeliveryStatus.COMINGBACK;
            }
            else if (totalTravelTime < route.RouteLenght && totalTravelTime > 0)
            {
                status = DeliveryStatus.DELIVERING;
            }
            else if(totalTravelTime == 2 * route.RouteLenght)
            {
                status = DeliveryStatus.FINISHED;
            }
            else if(totalTravelTime > 2 * route.RouteLenght) { throw new Exception("Not possible"); }
            drawCurrentRoad();
        }
        private void drawCurrentRoad()
        {
            int sum = 0;
            Road currentRoad = null;

            if (totalTravelTime <= route.RouteLenght)
            {
                for (int i = 0; i < route.Route.Count; i++)
                {
                    sum += route.Route[i].initialCost;
                    if (sum >= totalTravelTime)
                    {
                        currentRoad = route.Route[i];
                        break;
                    }
                }
            }
            else
            {
                sum = route.RouteLenght;
                for (int i = route.Route.Count - 1; i >= 0; i--)
                {
                    sum += route.Route[i].initialCost;
                    if (sum >= totalTravelTime)
                    {
                        currentRoad = route.Route[i];
                        break;
                    }
                }
            }
            if(previousColoredRoad != null)
            {
                previousColoredRoad.LineColor = Color.IndianRed;
            }
            currentRoad.LineColor = Color.Blue;
            previousColoredRoad = currentRoad;
            Map.RedrawMap();
        }
	}
}
