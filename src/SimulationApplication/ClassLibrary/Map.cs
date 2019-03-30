using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Linq;

namespace ClassLibrary
{
    public class Map : IEnumerable
    {
        private Random rng;
        private Cell[,] cells;

        public int NumberOfCells { get; set; }

        public Map(int numberOfLocations, int numberOfCells, int cellSize)
        {
            NumberOfCells = numberOfCells;
            Cell.CellSize = cellSize;
            cells = new Cell[NumberOfCells, NumberOfCells];
            for (int rowCount = 0; rowCount < NumberOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumberOfCells; columnCount++)
                {
                    cells[rowCount, columnCount] = new Cell(rowCount, columnCount);
                }
            }
            // Seed the random generator to get reproducable results.
            rng = new Random(0);

            while (numberOfLocations > 0)
            {
                Cell c = GenerateRandomLocation();
                if (c.Location == null)
                {
                    // Set location object to beparth of this cell 
                    // and decrement number of locations to be added to the cells/map.
                    c.Location = new Location(c.Index.Row, c.Index.Column);
                    numberOfLocations--;
                }
            }
        }

        public Cell[,] GetCells()
        {
            // Preferably this will be a copy, and perhaps not a shallow one.
            return cells;
        }

        public Location getCellByLocation(Location l)
        {
            foreach(Location loc in Vertices)
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

        public List<Location> Vertices = new List<Location>();
        public List<Road> Edges = new List<Road>();

        /// <summary>
        /// Returns Enumerator of Vertex-List in a graph.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return this.Vertices.GetEnumerator();
        }

        /// <summary>
        /// Returns a Vertex from Vertex-List
        /// </summary>
        public Location this[int index]
        {
            get { return this.Vertices[index]; }
        }

        /// <summary>
        /// Returns a Vertex count in a graph.
        /// </summary>
        public int V { get { return this.Vertices.Count; } }

        /// <summary>
        /// Streams all unvisited vertices in a graph.
        /// </summary>
        public IEnumerable<Location> nonVisited()
        {
            return (from v in this.OfType<Location>() where v.visited == false select v);
        }

        public List<Building> getShops()
        {
            return Vertices.Select(v => v.Building).Where(v => v is Shop).ToList();
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
            return (from v in this.OfType<Location>() where v.PositionX == x && v.PositionY == y select v).FirstOrDefault();
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
                this.Vertices.Add(v);
           

            //else
            //    System.Windows.Forms.MessageBox.Show("Vertex limit reached!", "Warning");
        }

        /// <summary>
        /// Removes vertex from graph then sorts all vertices by ID and recalculates Ids
        /// </summary>
        public void Remove(Location v)
        {

            this.Vertices.Remove(v);
            this.Vertices.Sort();

            for (int i = 0; i < V; i++)
                Vertices[i].LocationID = i;

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


    }
}
