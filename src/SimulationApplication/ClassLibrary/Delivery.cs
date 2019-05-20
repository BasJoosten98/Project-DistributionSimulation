using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public class Delivery
	{
        private int startTime; //when truck started working on this delivery
        private int createTime; //when the delivery object was made
        private DeliveryStatus status;
        private DijkstraRoute route;
        private int totalTravelTime; //Total traveled time units
        private Location nextLocation; //End location of the road
        private Road currentRoad; //Current road the vehicle is on
        private int deltaTravelTime; //Total traveled initial cost of the road

        public int StartTime { get { return startTime; } }
        public int CreateTime { get { return createTime; } }
        public DijkstraRoute Route { get { return route; } }
        public DeliveryStatus Status { get { return status; } }
        public int TotalTravelTime { get { return totalTravelTime; } }
        public Location NextLocation { get { return nextLocation; } }
        public Road CurrentRoad { get { return currentRoad; } }
        public int DeltaTravelTime { get { return deltaTravelTime; } }

        public Delivery(DijkstraRoute dRoute, Location startLoc, int timeStamp)
        {
            if(!(dRoute.EndPoint.Building is Shop)) { throw new Exception("Building needs to be a shop!"); }
            if(dRoute.Route[0].Vertex1 != startLoc && dRoute.Route[0].Vertex2 != startLoc) { throw new Exception("Unkown startLocation"); }
            route = dRoute;
            status = DeliveryStatus.NOTSTARTED;
            totalTravelTime = 0;
            createTime = timeStamp;
            if(dRoute.Route[0].Vertex1 == startLoc) { nextLocation = dRoute.Route[0].Vertex2; }
            else { nextLocation = dRoute.Route[0].Vertex1; }
            currentRoad = dRoute.Route[0];
        }

        /// <summary>
        /// Moving the delivery/vehicle 1 time unit ahead
        /// </summary>
        public void NextTick(int timeStamp)
        {
            if(startTime == 0)
            {
                startTime = timeStamp;
            }
            totalTravelTime++;
            int sum = 0;
            if(totalTravelTime <= route.RouteLenght) //vehicle is heading towards the shop
            {
                //CALCULATING THE NEW FIELD'S VARIABLES (NOT IMPORTANT, DON'T LOOK AT THIS)
                if (totalTravelTime == 1)
                {
                    status = DeliveryStatus.DELIVERING;
                }

                for (int i = 0; i < route.Route.Count; i++)
                {
                    sum += route.Route[i].initialCost;
                    if (sum >= totalTravelTime) //new next location
                    {
                        if (currentRoad != route.Route[i] && i != 0)
                        {
                            if (route.Route[i].Vertex1 == nextLocation) { nextLocation = route.Route[i].Vertex2; }
                            else { nextLocation = route.Route[i].Vertex1; }
                            currentRoad = route.Route[i];
                        }
                        break;
                    }
                }
                if (currentRoad.Vertex1 != nextLocation && currentRoad.Vertex2 != nextLocation) { throw new Exception("currentroad mismatches nextLocation"); }
                deltaTravelTime = currentRoad.initialCost - (sum - totalTravelTime);
                if (totalTravelTime == route.RouteLenght)
                {
                    status = DeliveryStatus.COMINGBACK;
                }
            }
            else if(totalTravelTime <= 2* route.RouteLenght) //vehicle is returning towards warehouse
            {
                //CALCULATING THE NEW FIELD'S VARIABLES (NOT IMPORTANT, DON'T LOOK AT THIS)
                if(totalTravelTime == route.RouteLenght + 1) { currentRoad = null; }
                sum = route.RouteLenght;
                for (int i = route.Route.Count - 1; i >= 0; i--)
                {
                    sum += route.Route[i].initialCost;
                    if (sum >= totalTravelTime) //new next location
                    {
                        if (currentRoad != route.Route[i])
                        {
                            if (route.Route[i].Vertex1 == nextLocation) { nextLocation = route.Route[i].Vertex2; }
                            else { nextLocation = route.Route[i].Vertex1; }
                            currentRoad = route.Route[i];
                        }
                        break;
                    }
                }
                if (currentRoad.Vertex1 != nextLocation && currentRoad.Vertex2 != nextLocation) { throw new Exception("currentroad mismatches nextLocation"); }
                deltaTravelTime = currentRoad.initialCost - (sum - totalTravelTime);
                if (totalTravelTime == 2 * route.RouteLenght)
                {
                    status = DeliveryStatus.FINISHED;
                }
                
            }
            else if(totalTravelTime > 2 * route.RouteLenght) { throw new Exception("Not possible"); }
        }
	}
}
