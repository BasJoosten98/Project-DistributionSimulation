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

        public void AddNewRoute(DijkstraRoute newRoute)
        {
            if (!isConnectedToLocation(newRoute.EndPoint))
            {
                routes.Add(newRoute);
            }            
        }

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
