using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DijkstraRoute
    {
        private List<Road> route;
        private Location endPoint;

        public List<Road> Route { get { return route; } }
        /// <summary>
        /// Determines the point in which the route ended
        /// </summary>
        public Location EndPoint { get { return endPoint; } }

        /// <summary>
        /// Shows the lengts of the route
        /// </summary>
        public int RouteLenght
        {
            get
            {
                int sum = 0;
                foreach (Road r in route)
                {
                    sum += r.initialCost;
                }
                return sum;
            }
        }


        public DijkstraRoute(List<Road> Route, Location EndPoint)
        {
            this.route = Route;
            endPoint = EndPoint;
        }
        /// <summary>
        /// Returns a copy of the current route.
        /// </summary>
        /// <returns>List<Road></returns>
        public List<Road> CopyRoute()
        {
            List<Road> temp = new List<Road>();
            foreach(Road r in route)
            {
                temp.Add(r);
            }
            return temp;
        }

    }
}
