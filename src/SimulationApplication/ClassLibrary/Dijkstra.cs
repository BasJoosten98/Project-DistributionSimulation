using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Dijkstra
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
            foreach(Location l in reachableLocations)
            {
                createDijkstraStart(l);
            }
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
            //string holder = "";

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
                List<Road> newRoute;
                if (previousDijkstraRoute != null)
                {
                    newRoute = previousDijkstraRoute.CopyRoute();
                    newRoute.Add(currentRoad);
                }
                else
                {
                    newRoute = new List<Road>();
                    newRoute.Add(currentRoad);
                }
                DijkstraRoute newDijkstraRoute = new DijkstraRoute(newRoute, newLocation);
                dijkstraStart.AddNewRoute(newDijkstraRoute);

                //holder += "PrevLocation: " + prevLocation.LocationID + "\n";

                //holder += "From " + startLocation.LocationID + " to " + newLocation.LocationID + ": \n";
                //foreach (Road r in newDijkstraRoute.Route)
                //{
                //    holder += "Road: " + r.Vertex1.LocationID + " - " + r.Vertex2.LocationID + "\n";
                //}
                //holder += "\n";

                //Determine new roads and remove currentRoad/exsiting roads
                currentRoads.RemoveAt(lowestIndex);
                currentRoadsLenghts.RemoveAt(lowestIndex);

                List<Road> newAddingRoads = getRoadsConnectedToLocation(newLocation);
                newAddingRoads.Remove(currentRoad);
                for(int i = 0; i < newAddingRoads.Count; i++) //filter out already existing roads in currentRoads
                {
                    if(dijkstraStart.isConnectedToLocation(newAddingRoads[i].Vertex1) && dijkstraStart.isConnectedToLocation(newAddingRoads[i].Vertex2))
                    {
                        if (currentRoads.Contains(newAddingRoads[i]))
                        {
                            int index = currentRoads.IndexOf(newAddingRoads[i]);
                            currentRoads.RemoveAt(index);
                            currentRoadsLenghts.RemoveAt(index);
                        }
                        newAddingRoads.RemoveAt(i);
                        i--;
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
            startingPoints.Add(dijkstraStart);
            //MessageBox.Show(holder);
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
            foreach (DijkstraStart s in startingPoints)
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
