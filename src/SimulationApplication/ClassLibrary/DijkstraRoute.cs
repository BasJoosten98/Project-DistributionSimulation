using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class DijkstraRoute
    {
        private List<Road> route;
        private Location endPoint;

        public List<Road> Route { get { return route; } }
        public Location EndPoint { get { return endPoint; } }
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
    }
}
