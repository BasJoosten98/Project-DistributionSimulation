using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Dijkstra
    {
        private List<DijkstraStart> startingPoints;
        private List<Road> allRoads;
        private List<Location> reachableLocations;

        public Dijkstra(List<Road> Roads)
        {
            if(Roads == null) { throw new NullReferenceException(); }
            if(Roads.Count == 0) { throw new Exception("Roads should contain atleast 1 road"); }

            startingPoints = new List<DijkstraStart>();
            reachableLocations = new List<Location>();
            allRoads = Roads;
            detectedLocations();
            createDijkstraStart(reachableLocations[0]);
        }
        
        private List<Road> getRoadsConnectedToLocation(Location loc)
        {
            List<Road> roadList = new List<Road>();
            foreach(Road r in allRoads)
            {
                if(r.Vertex1 == loc || r.Vertex2 == loc)
                {
                    roadList.Add(r);
                }
            }
            return roadList;
        }
        private int findLowestIndex(List<int> list)
        {
            if (list == null) { throw new NullReferenceException(); }
            if (list.Count == 0) { throw new Exception("Internal problem: empty list"); }

            int lowestIndex = 0;
            for(int i = 1; i < list.Count; i++)
            {
                if(list[i] < list[lowestIndex])
                {
                    lowestIndex = i;
                }
            }
            return lowestIndex;
        }

        private void createDijkstraStart(Location startLocation) //main methods for creating shortest routes accros the map
        {
            List<Road> currentRoads = new List<Road>(); //considered roads at the moment
            List<int> currentRoadsLenghts = new List<int>(); //road lenghts
            DijkstraStart dijkstraStart = new DijkstraStart(startLocation);

            currentRoads = getRoadsConnectedToLocation(startLocation);
            foreach (Road r in currentRoads)
            {
                currentRoadsLenghts.Add(r.initialCost);
            }

            int lowestIndex;
            Road currentRoad;
            int currentRoadLenght;
            Location prevLocation = null;
            Location newLocation = null;

            while (currentRoads.Count != 0)
            {
                //get next shortest route
                lowestIndex = findLowestIndex(currentRoadsLenghts);
                currentRoad = currentRoads[lowestIndex];
                currentRoadLenght = currentRoadsLenghts[lowestIndex];

                //claim new shortest route
                if (dijkstraStart.isConnectedToLocation(currentRoad.Vertex1)) { prevLocation = currentRoad.Vertex1; } else { newLocation = currentRoad.Vertex1; }
                if (dijkstraStart.isConnectedToLocation(currentRoad.Vertex2)) { prevLocation = currentRoad.Vertex2; } else { newLocation = currentRoad.Vertex2; }
                if (prevLocation == null) { throw new NullReferenceException(); }
                if (newLocation == null) { throw new NullReferenceException(); }
                DijkstraRoute previousDijkstraRoute = dijkstraStart.GetRouteTo(prevLocation);
                if(previousDijkstraRoute == null) { throw new NullReferenceException(); }
                List<Road> newRoute = previousDijkstraRoute.Route;
                newRoute.Add(currentRoad);
                DijkstraRoute newDijkstraRoute = new DijkstraRoute(newRoute, newLocation);
                dijkstraStart.AddNewRoute(newDijkstraRoute);

                //Determine new roads and remove currentRoad/exsiting roads
                currentRoads.RemoveAt(lowestIndex);
                currentRoadsLenghts.RemoveAt(lowestIndex);

                List<Road> newAddingRoads = getRoadsConnectedToLocation(newLocation);
                newAddingRoads.Remove(currentRoad);
                foreach(Road r in newAddingRoads) //filter out already existing roads in currentRoads
                {
                    if(dijkstraStart.isConnectedToLocation(r.Vertex1) && dijkstraStart.isConnectedToLocation(r.Vertex2))
                    {
                        if (currentRoads.Contains(r))
                        {
                            int index = currentRoads.IndexOf(r);
                            currentRoads.RemoveAt(index);
                            currentRoadsLenghts.RemoveAt(index);
                        }
                        newAddingRoads.Remove(r);
                    }
                }

                //Adding new roads and calculating new roads lenghts
                foreach(Road r in newAddingRoads)
                {
                    int roadLenght = r.initialCost + currentRoadLenght;
                    currentRoads.Add(r);
                    currentRoadsLenghts.Add(roadLenght);
                }

                //reseting values
                currentRoad = null;
                prevLocation = null;
                newLocation = null;
                currentRoadLenght = -1;
                lowestIndex = -1;
            }
            currentRoad = null;
        }

        private void detectedLocations() //Find all reachable locations with the given Roads
        {
            reachableLocations = new List<Location>();
            foreach (Road r in allRoads)
            {
                if (!reachableLocations.Contains(r.Vertex1))
                {
                    reachableLocations.Add(r.Vertex1);
                }
                if (!reachableLocations.Contains(r.Vertex2))
                {
                    reachableLocations.Add(r.Vertex2);
                }
            }
        }

        public DijkstraRoute GetRouteTo(Location StartPoint, Location EndPoint) //Getting route from StartPoint to EndPoint
        {
            foreach(DijkstraStart s in startingPoints)
            {
                if(s.StartPoint == StartPoint)
                {
                    return s.GetRouteTo(EndPoint);
                }
            }
            return null;
        }
    }
}
