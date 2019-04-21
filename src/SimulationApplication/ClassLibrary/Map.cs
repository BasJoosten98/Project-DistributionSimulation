using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Map : IEnumerable, ICloneable
    {
        public List<Location> Warehouses { get; }
        public List<Location> Shops { get; }
        public List<Location> Locations = new List<Location>();
        public List<Road> Edges = new List<Road>();
        private Random rng;
        private Cell[,] cells;
        private static PictureBox mapPicBox;
        private DistributionManager distributionManager;

        public int NumberOfCells { get; set; }
        public DistributionManager DistManager { get { return distributionManager; } }

        public Map(int numberOfLocations, int numberOfCells, int cellSize, PictureBox MapBox)
        {
            Warehouses = new List<Location>();
            Shops = new List<Location>();
            mapPicBox = MapBox;
            NumberOfCells = numberOfCells;
            Cell.CellSize = cellSize;
            cells = new Cell[NumberOfCells, NumberOfCells];
            for (int rowCount = 0; rowCount < NumberOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumberOfCells; columnCount++)
                {
                    cells[columnCount, rowCount] = new Cell(columnCount, rowCount);
                }
            }
            // Seed the random generator to get reproducable results.
            rng = new Random(0);

            while (numberOfLocations > 0)
            {
                Cell c = GenerateRandomLocation();
                if (!(c is Location))
                {
                    // Set location object to beparth of this cell 
                    // and decrement number of locations to be added to the cells/map.
                    //c.Location = new Location(c.Index.Row, c.Index.Column);
                    Location newLocation = new Location(c.Index.Column, c.Index.Row);
                    cells[c.Index.Column, c.Index.Row] = newLocation;
                    // Add the cell's location object to the list of vertices.
                    // Refactor later, Bas' comment (Location is more specific version of cell) so it can inherit from Cell.
                    Locations.Add(newLocation);
                    newLocation.Demand = 2;
                    numberOfLocations--;
                }
            }
            Console.WriteLine(V);

            // Hard coded roads/edges from location 
            // 1 -> 2, weight: 3
            Edges.Add(new Road(Locations[0], Locations[1]));
            // 2 -> 3, weight: 1
            Edges.Add(new Road(Locations[1], Locations[2]));
            // 1 -> 3, weight: 1
            Edges.Add(new Road(Locations[0], Locations[2]));
            // 3 -> 6, weight: 1
            Edges.Add(new Road(Locations[2], Locations[5]));
            // 6 -> 7, weight: 1
            Edges.Add(new Road(Locations[5], Locations[6]));
            // 1 -> 9, weight: 1
            Edges.Add(new Road(Locations[0], Locations[8]));
            // 4 -> 9, weight: 1
            Edges.Add(new Road(Locations[3], Locations[8]));
            // 4 -> 5, weight: 1
            Edges.Add(new Road(Locations[3], Locations[4]));
            // 5 -> 8, weight: 1
            Edges.Add(new Road(Locations[4], Locations[7]));
            // 10 -> 8, weight: 1
            Edges.Add(new Road(Locations[9], Locations[7]));
            // 10 -> 5, weight: 1
            Edges.Add(new Road(Locations[9], Locations[4]));

            foreach(Road r in Edges)
            {
                r.initialCost = rng.Next(1, 4);
            }
        }

        public void nextTick()
        {
            foreach(Location w in Warehouses)
            {
                ((Warehouse)w.Building).nextTick();
            }
            foreach(Location s in Shops)
            {
                ((Shop)s.Building).nextTick(s.Demand);
            }
            distributionManager.nextTick();
        }
        public void CreateDistributionManager() //should be called when map is forseen with warehouses and shops!
        {
            Dijkstra dijkstra = new Dijkstra(Edges);
            distributionManager = new DistributionManager(dijkstra, Warehouses, Shops);
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
            }
        }
        public void RemoveBuilding(Location l)
        {
            if (l.Building is Warehouse)
            {
                Warehouses.Remove(l);
            }
            else if (l.Building is Shop)
            {
                Shops.Remove(l);
            }
            l.Building = null;
        }
        public static void RedrawMap()
        {
            mapPicBox.Invalidate();
        }
        public static void RedrawMapNow()
        {
            mapPicBox.Refresh();
        }

        public Cell[,] GetCells()
        {
            // Preferably this will be a copy, and perhaps not a shallow one.
            return cells;
        }

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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
