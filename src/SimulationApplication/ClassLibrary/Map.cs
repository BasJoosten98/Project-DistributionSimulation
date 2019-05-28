using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Map : IEnumerable
    {
        public Entities.Map MapEntity { get; }
        private List<Location> warehouses = new List<Location>();
        private List<Statistics> statistics = new List<Statistics>();
        private List<Location> shops = new List<Location>();
        private List<Location> locations = new List<Location>();
        private List<Road> edges = new List<Road>();
        private Random rng;
        private Random rng2;
        private Cell[,] cells;
        private static PictureBox mapPicBox;
        private DistributionManager distributionManager;

        public int NumberOfCells { get; set; }
        public DistributionManager DistManager { get { return distributionManager; } }
        public List<Location> Warehouses { get { return warehouses; } }
        public List<Statistics> Statistics { get { return statistics; } }
        public List<Location> Shops { get { return shops; } }
        public List<Location> Locations { get { return locations; } }
        public List<Road> Edges { get { return edges; } }

        /// <summary>
        /// Creates a map objects and initializes with the given values
        /// </summary>
        /// <param name="numberOfLocations"></param>
        /// <param name="numberOfCells"></param>
        /// <param name="cellSize"></param>
        /// <param name="MapBox"></param>
        public Map(int numberOfLocations, int numberOfCells, int cellSize, PictureBox MapBox)
        {
            // Construct the map entity.
            MapEntity = new Entities.Map() { CellSize = cellSize, NumberOfCells = numberOfCells };

            mapPicBox = MapBox;
            NumberOfCells = numberOfCells;
            Cell.CellSize = cellSize;
            cells = new Cell[NumberOfCells, NumberOfCells];
            for (int rowCount = 0; rowCount < NumberOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumberOfCells; columnCount++)
                {
                    Cell c = new Cell(columnCount, rowCount);
                    cells[columnCount, rowCount] = c;
                }
            }

            // Seed the random generator to get reproducable results.
            rng = new Random(0);
            rng2 = new Random();

            int demand;
            foreach (Cell c in cells)
            {
                demand = rng2.Next(2, 5);
                c.SetDemandGrow(demand);
            }


            while (numberOfLocations > 0)
            {
                Cell c = GenerateRandomLocation();
                if (!(c is Location))
                {
                    // and decrement number of locations to be added to the cells/map.
                    Location newLocation = ChangeCellIntoLocation(c, 2);
                    Locations.Add(newLocation);
                    numberOfLocations--;
                }
            }
            // Prints the count property of the List of location objects.
            Console.WriteLine(V);

            // Create and add roads to the map entity
            // 1 -> 2, weight: 3
            Road r = new Road(Locations[0], Locations[1]);
            Edges.Add(r);
            // 2 -> 3, weight: 1
            r = new Road(Locations[1], Locations[2]);
            Edges.Add(r);
            // 1 -> 3, weight: 1
            r = new Road(Locations[0], Locations[2]);
            Edges.Add(r);
            // 3 -> 6, weight: 1
            r = new Road(Locations[2], Locations[5]);
            Edges.Add(r);
            // 6 -> 7, weight: 1
            r = new Road(Locations[5], Locations[6]);
            Edges.Add(r);
            // 1 -> 9, weight: 1
            r = new Road(Locations[0], Locations[8]);
            Edges.Add(r);
            // 4 -> 9, weight: 1
            r = new Road(Locations[3], Locations[8]);
            Edges.Add(r);
            // 4 -> 5, weight: 1
            r = new Road(Locations[3], Locations[4]);
            Edges.Add(r);
            // 5 -> 8, weight: 1
            r = new Road(Locations[4], Locations[7]);
            Edges.Add(r);
            // 10 -> 8, weight: 1
            r = new Road(Locations[9], Locations[7]);
            Edges.Add(r);
            // 10 -> 5, weight: 1
            r = new Road(Locations[9], Locations[4]);
            Edges.Add(r);
        }

        public void ResetMap()
        {
            statistics.Clear();
            createDistributionManager();
            Cell.Reset();
            foreach(Cell c in cells)
            {
                c.CellReset();
            }
            foreach(Location l in shops)
            {
                Shop s = (Shop)l.Building;
                s.ShopReset();
            }
            foreach(Location l in warehouses)
            {
                Warehouse w = (Warehouse)l.Building;
                w.ResetWarehouse();
            }
        }
        public void RandomizeDemand()
        {
            foreach (Cell c in cells)
            {
                c.SetDemandGrow(rng2.Next(2, 5));
            }
        }
        public void RandomizeLocationsAndRoads()
        {
            Location.ResetLocationId();
            int numberOfLocations = rng2.Next(1, (int)Math.Floor((double)(NumberOfCells*NumberOfCells)/ 10));

            //remove all locations
            for(int i = 0; i < locations.Count; i++)
            {
                if(locations[i].Building != null)
                {
                    RemoveBuilding(locations[i]);
                }
                ChangeLocationIntoCell(locations[i]);
                i = -1;
            }

            //place new loactions
            List<Cell> tempCells = new List<Cell>();
            foreach(Cell c in cells)
            {
                tempCells.Add(c);
            }

            int nextCell;
            double nextMax = (double)tempCells.Count / numberOfLocations;
            for(int i = 1; i <= numberOfLocations; i++)
            {
                nextCell = rng2.Next((int)Math.Floor((i-1) * nextMax), (int)Math.Floor(i * nextMax));
                Cell c = tempCells[nextCell];
                if(!(c is Location))
                {
                    Location l = ChangeCellIntoLocation(c, 2);
                    locations.Add(l);
                }
            }

            //connect locations with roads
            for (int i = 0; i < locations.Count - 1; i++)
            {
                AddNewRoad(locations[i], locations[i + 1], rng2.Next(1, 6));
            }
            Console.WriteLine("Map has been randomized with " + numberOfLocations + " locations (MAX = " + (int)Math.Floor((double)(NumberOfCells * NumberOfCells) / 10) + ")");
        }
        /// <summary>
        /// Changes Cell into Location
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Location ChangeCellIntoLocation(Cell c, int radius)
        {
            Location l = new Location(c.Index.Column, c.Index.Row, radius);
            l.SetDemandGrow(c.Demand);
            cells[c.Index.Column, c.Index.Row] = l;

            return l;
        }
        /// <summary>
        /// Changes Location into Cell
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public Cell ChangeLocationIntoCell(Location l)
        {
            Cell c = new Cell(l.Index.Column, l.Index.Row);
            c.SetDemandGrow(l.Demand);
            cells[l.Index.Column, l.Index.Row] = c;
            Locations.Remove(l);

            // Remove the roads from the road collection.
            for (int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].Vertex1 == l || Edges[i].Vertex2 == l)
                {
                    Edges.RemoveAt(i);
                    i--;
                }
            }
            return c;
        }

        public void NextTick(int timeStamp)
        {
            List<Cell> tempList = new List<Cell>();
            foreach(Cell c in cells)
            {
                tempList.Add(c);
            }
            while(tempList.Count > 0)
            {
                int r = rng2.Next(0, tempList.Count);
                tempList[r].NextTick(timeStamp);
                tempList.RemoveAt(r);
            }
            distributionManager.NextTick(timeStamp);
            foreach (Location w in Warehouses)
            {
                ((Warehouse)w.Building).NextTick(timeStamp);
            }
            updateStatistics(timeStamp);
        }
        private void updateStatistics(int timeStamp)
        {
            foreach(Location s in Shops)
            {
                Statistics.Add(((Shop)s.Building).MakeStatistics(timeStamp));
            }
            foreach (Location w in Warehouses)
            {
                Statistics.Add(((Warehouse)w.Building).MakeStatistics(timeStamp));
            }
        }
        private void createDistributionManager() //should be called when map is forseen with warehouses and shops!
        {
            Dijkstra dijkstra = new Dijkstra(Edges);
            distributionManager = new DistributionManager(dijkstra, Warehouses, Shops);
        }
        /// <summary>
        /// Preparing Map and all it's atributes for the start of the simulation
        /// </summary>
        public void PrepareForSimulation()
        {
            createDistributionManager();

        }
        public bool AddNewRoad(Location l1, Location l2, int cost)
        {
            Road r = getRoadByLocations(l1, l2);
            if (r == null)
            {
                Road temp = new Road(l1, l2);
                temp.initialCost = cost;

                // Road entity
                temp.RoadEntity.InitialCost = cost;
 //              MapEntity.Roads.Add(temp.RoadEntity); //------------------------------------------------------------------------------

                Edges.Add(temp);
                return true;
            }
            return false;
        }
        private Road getRoadByLocations(Location l1, Location l2)
        {
            foreach (Road r in Edges)
            {
                if ((r.Vertex1 == l1 && r.Vertex2 == l2) || (r.Vertex1 == l2 && r.Vertex2 == l1))
                {
                    return r;
                }
            }
            return null;
        }
        public bool RemoveRoad(Location l1, Location l2)
        {
            Road r = getRoadByLocations(l1, l2);
            if(r != null)
            {
                Edges.Remove(r);
                return true;
            }
            return false;
        }
        public void AddNewBuilding(Location l)
        {
            if(l.Building is Warehouse)
            {
                Warehouses.Add(l);
            }
            else if (l.Building is Shop)
            {
                Shops.Add(l);
                applyShopRadiusToCells(l);
            }
        }
        private Cell getCellByIndex(int column, int row)
        {
            foreach(Cell c in cells)
            {
                if(c.Index.Column == column && c.Index.Row == row)
                {
                    return c;
                }
            }
            return null;
        }
        /// <summary>
        /// Provide shopRadius to all nearby Cells (based on the Radius of the given Shop)
        /// </summary>
        /// <param name="shopLocation"></param>
        private void applyShopRadiusToCells(Location shopLocation)
        {
            Shop shop = (Shop)shopLocation.Building;
            int downPerDistance = (int)Math.Floor((double)100 / (shopLocation.Radius + 1));
            for(int col = shopLocation.Index.Column - shopLocation.Radius; col <= shopLocation.Index.Column + shopLocation.Radius; col++)
            {
                for (int row = shopLocation.Index.Row - shopLocation.Radius; row <= shopLocation.Index.Row + shopLocation.Radius; row++)
                {
                    Cell c = getCellByIndex(col, row);
                    if(c != null)
                    {
                        int distance;
                        if(Math.Abs(row - shopLocation.Index.Row) > Math.Abs(col - shopLocation.Index.Column))
                        {
                            distance = Math.Abs(row - shopLocation.Index.Row);
                        }
                        else
                        {
                            distance = Math.Abs(col - shopLocation.Index.Column);
                        }
                        int demandPercentage = 100 - distance * downPerDistance;
                        c.AddShopRadius(shop, demandPercentage);
                    }
                }
            }

        }

        private void removeShopRadiusFromCells(Shop s)
        {
            foreach(Cell c in cells)
            {
                c.RemoveShopRadius(s);
            }
        }

        public void RemoveBuilding(Location l)
        {
            if (l.Building is Warehouse)
            {
                Warehouses.Remove(l);
                l.Building.picBox.Dispose();
                ((Warehouse)l.Building).RemoveAllvehicles();                
            }
            else if (l.Building is Shop)
            {
                Shops.Remove(l);
                removeShopRadiusFromCells((Shop)l.Building);
                l.Building.picBox.Dispose();
            }
            l.Building = null;
            // Set the entity's building to null as well.
//            l.LocationEntity.Building = null; //------------------------------------------------------------------------------
        }

        /// <summary>
        /// Redraws the map 
        /// </summary>
        public static void RedrawMap()
        {
            mapPicBox.Invalidate();
        }
        /// <summary>
        /// Redraws the map fast
        /// </summary>
        public static void RedrawMapNow()
        {
            mapPicBox.Refresh();
        }

        /// <summary>
        /// Returns a copy of the cells NOT IMPLEMENTD YET
        /// </summary>
        /// <returns></returns>
        public Cell[,] GetCells()
        {
            // Preferably this will be a copy, and perhaps not a shallow one.
            return cells;
        }

        /// <summary>
        /// Returns a specific location by the inputed LocationID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Location</returns>
        public Location GetLocationByID(int id)
        {
            foreach(Location l in Locations)
            {
                if(l.LocationID == id)
                {
                    return l;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns a specific cell by the specified location
        /// </summary>
        /// <param name="l"></param>
        /// <returns>Location</returns>
        public Location getCellByLocation(Location l)
        {
            foreach(Location loc in Locations)
            {
                if(loc.LocationPoint == l.LocationPoint)
                {
                    return loc;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a cell at index [x, y] where x and y are numbers between 0 and NumOfCells (exclusive)
        /// </summary>
        /// <returns></returns>
        private Cell GenerateRandomLocation()
        {
            // Return a cell at index [x, y] where x and y are numbers between 0 and NumOfCells (exclusive)
            return cells[rng.Next(0, NumberOfCells), rng.Next(0, NumberOfCells)]; 
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------   

        /// <summary>
        /// Returns Enumerator of Vertex-List in a graph.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return this.Locations.GetEnumerator();
        }

        /// <summary>
        /// Returns a Vertex from Vertex-List
        /// </summary>
        public Location this[int index]
        {
            get { return this.Locations[index]; }
        }

        /// <summary>
        /// Returns a Vertex count in a graph.
        /// </summary>
        public int V { get { return this.Locations.Count; } }

        /// <summary>
        /// Streams all unvisited vertices in a graph.
        /// </summary>
        public IEnumerable<Location> nonVisited()
        {
            return (from v in this.OfType<Location>() where v.visited == false select v);
        }

        public List<Building> getShops()
        {
            return Locations.Select(v => v.Building).Where(v => v is Shop).ToList();
        }

        /// <summary>
        /// Streams all vertices whose 'permanent variable' is false.
        /// </summary>
        public IEnumerable<Location> nonPermanent()
        {
            return (from v in this.OfType<Location>() where v.permanent == false select v);
        }

        /// <summary>
        /// Returns vertex of who x and y coordinates match with entered.
        /// </summary>
        public Location Get(int x, int y)
        {
            return (from v in this.OfType<Location>() where v.Index.Column == x && v.Index.Row == y select v).FirstOrDefault();
        }

        /// <summary>
        /// Returns an Edge of two vertices.
        /// </summary>
        public Road Get(Location V1, Location V2)
        {
            return (from e in this.Edges where (e[0] == V1 && e[1] == V2) || (e[0] == V2 && e[1] == V1) select e).FirstOrDefault();
        }

        /// <summary>
        /// Adds a new Vertex to a graph.
        /// </summary>
        public void Add(Location v)
        {

            if (this.V < 10) // instead of 10 here we should put the vertex limit
                this.Locations.Add(v);
           

            //else
            //    System.Windows.Forms.MessageBox.Show("Vertex limit reached!", "Warning");
        }

        /// <summary>
        /// Removes vertex from graph then sorts all vertices by ID and recalculates Ids
        /// </summary>
        public void Remove(Location v)
        {

            this.Locations.Remove(v);
            this.Locations.Sort();

            for (int i = 0; i < V; i++)
                Locations[i].LocationID = i;

            this.Disconnect(v);
        }

        /// <summary>
        /// Connects two vertices (Creates an Edge (If already exists - increases cost by INITIAL_COST constant))
        /// </summary>
        public void Connect(Location V1, Location V2)
        {

            foreach (Road e in this.Edges)
                if ((e[0] == V1 && e[1] == V2) || (e[0] == V2 && e[1] == V1))
                {

                    e.initialCost += 1;

                    return;
                }

            this.Edges.Add(new Road(V1, V2));
        }

        /// <summary>
        /// Removes all connections from a Vertex.
        /// </summary>
        public void Disconnect(Location v)
        {

            Stack<Road> garbage = new Stack<Road>();

            foreach (Road e in this.Edges)
                if (e[0] == v || e[1] == v)
                {

                    garbage.Push(e);
                }

            while (garbage.Count > 0)
                this.Edges.Remove(garbage.Pop());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Calculates the shortest distance between vertices using Dijkstra's algorithm.
        /// </summary>
        public static void Dijkstra(Map _Graph, int start_id)
        {

            Location initial = _Graph[start_id];

            initial.min_cost = 0;
            initial.permanent = true;
            initial.source_id = initial.LocationID;

            for (int i = 0; i < _Graph.V; i++)
            {

                int min_cost = int.MaxValue;
                int index = 0;

                foreach (Location v in _Graph.nonPermanent())
                {

                    if (_Graph.Get(initial, v) != null)
                        if (initial + _Graph.Get(initial, v) < v.min_cost)
                        {
                            v.min_cost = initial + _Graph.Get(initial, v);
                            v.source_id = initial.LocationID;
                        }

                    if (v.min_cost < min_cost)
                    {

                        min_cost = v.min_cost;
                        index = v.LocationID;
                    }
                }

                _Graph[index].permanent = true;
                initial = _Graph[index];
            }
        }
    }
}
