using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Graphics gMap;
        private Font fontMap;
        private Pen pMap;

        public Dijkstra(List<Road> Roads, Graphics g, Font font)
        {
            if(Roads == null) { throw new NullReferenceException(); }
            if(Roads.Count == 0) { throw new Exception("Roads should contain atleast 1 road"); }
            gMap = g;
            fontMap = font;
            pMap = new Pen(Color.Black);
            startingPoints = new List<DijkstraStart>();
            reachableLocations = new List<Location>();
            allRoads = Roads;
            detectedLocations();
            foreach(Location l in reachableLocations)
            {
                createDijkstraStart(l, false);
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

        public void createDijkstraStart(Location startLocation, bool animate) //main methods for creating shortest routes accros the map
        {
            if (!reachableLocations.Contains(startLocation)) { throw new Exception("Unknown location detected"); }
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

                //ANIMATION
                if (animate)
                {
                    AnimationDraw(currentRoads, Color.Yellow);
                    System.Threading.Thread.Sleep(2000);
                    AnimationDraw(new List<Road>() { currentRoad }, Color.Green);
                    //System.Threading.Thread.Sleep(1500);
                }

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
            if (!animate) { startingPoints.Add(dijkstraStart); }         
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
        private void AnimationDraw(List<Road> list1, Color col1)
        {
            //foreach (Road r in allRoads) //draw roads like normal
            //{
            //    r.DrawLine(gMap);
            //    r.DrawString(gMap, fontMap);
            //}
            foreach (Road r in list1)
            {
                r.DrawLine(gMap, col1);
                r.DrawString(gMap, fontMap);
            }
            //Draw all cells and locations
            foreach (Location l in reachableLocations) //draw locations over newly drawn roads
            {
                l.DrawMe(gMap, pMap, fontMap);
            }
        }
    }
}
