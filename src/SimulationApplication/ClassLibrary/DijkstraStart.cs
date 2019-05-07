using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DijkstraStart
    {
        private Location startPoint;
        private List<DijkstraRoute> routes;

        public Location StartPoint { get { return startPoint; } }
        public DijkstraStart(Location StartPoint)
        {
            startPoint = StartPoint;
            routes = new List<DijkstraRoute>();
        }


        /// <summary>
        /// Adds a new  possible route to the current existing routes
        /// </summary>
        /// <param name="newRoute"></param>
       public void AddNewRoute(DijkstraRoute newRoute)  
        {
            if (!isConnectedToLocation(newRoute.EndPoint))
            {
                routes.Add(newRoute);
            }            
        }

        /// <summary>
        /// Returns the best route to the specified destination
        /// </summary>
        /// <param name="Destination"></param>
        /// <returns>DikkstraRoute</returns>
        public DijkstraRoute GetRouteTo(Location Destination)
        {
            foreach(DijkstraRoute r in routes)
            {
                if(Destination == r.EndPoint)
                {
                    return r;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks to see if the given location is connected to any of the available routes
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool isConnectedToLocation(Location loc)
        {
            if(loc == startPoint) { return true; }
            foreach(DijkstraRoute r in routes)
            {
                if(r.EndPoint == loc)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
