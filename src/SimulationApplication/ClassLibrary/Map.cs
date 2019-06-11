using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class Map : IEnumerable
    {
        // Always call save on the map first, then assign that returned ID
        // to the map and save all the dependent entities.
        public int Id { get; set; }

        private List<Location> warehouses = new List<Location>();
        private List<Statistics> statistics = new List<Statistics>();
        private List<Location> shops = new List<Location>();
        private List<Location> locations = new List<Location>();
        private List<Road> edges = new List<Road>();
        private Random rng;
        private Random rng2;
        public Cell[,] cells;
        public Cell[,] Cells { get; set; }
        public static PictureBox mapPicBox;
        private DistributionManager distributionManager;

        public int mapLocationID = 0;
        public int NumberOfCells { get; set; }
        public int NumberOfLocations { get; set; }
        public int CellSize { get; set; }
        public DistributionManager DistManager { get { return distributionManager; } }
        public List<Location> Warehouses { get { return warehouses; } }
        public List<Statistics> Statistics { get { return statistics; } }
        public List<Location> Shops { get { return shops; } }
        public List<Location> Locations { get { return locations; } }
        public List<Road> Edges { get { return edges; } }

        public Map(int numberOfCells, int cellSize)
        {
            NumberOfCells = numberOfCells > 0 ? numberOfCells : 0;
            Cell.CellSize = cellSize;
            CellSize = cellSize;

            Cells = new Cell[NumberOfCells, NumberOfCells];

            // Seed the random generator to get reproducable results.
            rng = new Random(0);
            rng2 = new Random();
        }

        public Map(int numberOfLocations, int numberOfCells, int cellSize)
        {
            // Construct the map entity.
            NumberOfLocations = numberOfLocations;
            NumberOfCells = numberOfCells;
            Cell.CellSize = cellSize;
            Cells = new Cell[NumberOfCells, NumberOfCells];
            for (int rowCount = 0; rowCount < NumberOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumberOfCells; columnCount++)
                {
                    Cell c = new Cell(columnCount, rowCount);
                    Cells[columnCount, rowCount] = c;
                }
            }
        }


        /// <summary>
        /// Creates a map objects and initializes with the given values
        /// </summary>
        /// <param name="numberOfLocations"></param>
        /// <param name="numberOfCells"></param>
        /// <param name="cellSize"></param>
        /// <param name="MapBox"></param>
        public Map(int numberOfCells, int cellSize, PictureBox MapBox, int numberOfLocations = 10) : this(numberOfCells, cellSize)
        {
            NumberOfLocations = numberOfLocations > 0 ? numberOfLocations : 0;
            mapPicBox = MapBox;
            for (int rowCount = 0; rowCount < NumberOfCells; rowCount++)
            {
                for (int columnCount = 0; columnCount < NumberOfCells; columnCount++)
                {
                    Cell c = new Cell(columnCount, rowCount);
                    Cells[columnCount, rowCount] = c;
                }
            }

            int demand;
            foreach (Cell c in Cells)
            {
                demand = rng2.Next(2, 5);
                c.SetDemandGrow(demand);
            }

            numberOfLocations = numberOfLocations > (numberOfCells * numberOfCells) ? (numberOfCells * numberOfCells) : numberOfLocations;
            if (numberOfCells > 0)
            {
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

                if (NumberOfLocations == 10)
                {
                    CreateFixedRoads();
                }
            }
        }

        private void CreateFixedRoads()
        {
            // Create and add roads to the map entity
            // 1 -> 2, weight: 3
            AddRoadWithRandomWeight(Locations[0], Locations[1]);
            // 2 -> 3, weight: 1
            AddRoadWithRandomWeight(Locations[1], Locations[2]);
            // 1 -> 3, weight: 1
            AddRoadWithRandomWeight(Locations[0], Locations[2]);
            // 3 -> 6, weight: 1
            AddRoadWithRandomWeight(Locations[2], Locations[5]);
            // 6 -> 7, weight: 1
            AddRoadWithRandomWeight(Locations[5], Locations[6]);
            // 1 -> 9, weight: 1
            AddRoadWithRandomWeight(Locations[0], Locations[8]);
            // 4 -> 9, weight: 1
            AddRoadWithRandomWeight(Locations[3], Locations[8]);
            // 4 -> 5, weight: 1
            AddRoadWithRandomWeight(Locations[3], Locations[4]);
            // 5 -> 8, weight: 1
            AddRoadWithRandomWeight(Locations[4], Locations[7]);
            // 10 -> 8, weight: 1
            AddRoadWithRandomWeight(Locations[9], Locations[7]);
            // 10 -> 5, weight: 1
            AddRoadWithRandomWeight(Locations[9], Locations[4]);
        }

        private void AddRoadWithRandomWeight(Location l1, Location l2)
        {
            Road r = new Road(l1, l2);
            r.InitialCost = rng2.Next(2, 5);
            Edges.Add(r);
        }

        public void ResetMap()
        {
            statistics.Clear();
            createDistributionManager();
            Cell.Reset();
            foreach (Cell c in Cells)
            {
                c.CellReset();
            }
            foreach (Location l in shops)
            {
                Shop s = (Shop)l.Building;
                s.ShopReset();
            }
            foreach (Location l in warehouses)
            {
                Warehouse w = (Warehouse)l.Building;
                w.ResetWarehouse();
            }
        }
        public void RandomizeDemand()
        {
            foreach (Cell c in Cells)
            {
                c.SetDemandGrow(rng2.Next(2, 5));
            }
        }
        public void RandomizeLocationsAndRoads()
        {

            int numberOfLocations = rng2.Next(1, (int)Math.Floor((double)(NumberOfCells * NumberOfCells) / 10));

            //remove all locations
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].Building != null)
                {
                    RemoveBuilding(locations[i]);
                }
                ChangeLocationIntoCell(locations[i]);
                i = -1;
            }


            //place new loactions
            List<Cell> tempCells = new List<Cell>();
            foreach (Cell c in Cells)
            {
                tempCells.Add(c);
            }

            int nextCell;
            double nextMax = (double)tempCells.Count / numberOfLocations;
            for (int i = 1; i <= numberOfLocations; i++)
            {
                nextCell = rng2.Next((int)Math.Floor((i - 1) * nextMax), (int)Math.Floor(i * nextMax));
                Cell c = tempCells[nextCell];
                if (!(c is Location))
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
            mapLocationID++;
            Location l = new Location(mapLocationID, c.Index.Column, c.Index.Row, radius);
            l.SetDemandGrow(c.Demand);
            Cells[c.Index.Column, c.Index.Row] = l;

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
            Cells[l.Index.Column, l.Index.Row] = c;
            Locations.Remove(l);

            // Remove the roads from the road collection.
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].Vertex1 == l || Edges[i].Vertex2 == l)
                {
                    Edges.RemoveAt(i);
                    i--;
                }
            }
            return c;
        }

        public void RemoveAllBuildings()
        {
            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].Building != null)
                {
                    RemoveBuilding(locations[i]);
                }
            }
        }

        public void NextTick(int timeStamp)
        {
            List<Cell> tempList = new List<Cell>();
            foreach (Cell c in Cells)
            {
                tempList.Add(c);
            }
            while (tempList.Count > 0)
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

        bool firstLoop = true;
        private void updateStatistics(int timeStamp)
        {
            //if (firstLoop == true)
            //{
                foreach (Location s in Shops)
                {  
                    Statistics.Add(((Shop)s.Building).MakeStatistics(timeStamp));
                }
                foreach (Location w in Warehouses)
                {
                    Statistics.Add(((Warehouse)w.Building).MakeStatistics(timeStamp));
                }
            //    firstLoop = false;
            //}
            //else // added this to ensure that the statistics don't overlap and you only have statistics for the current 4 warehouses not more.
            //{
            //    foreach (var stats in Statistics.Where(x => x is StatisticsShop))
            //    {
            //        Statistics.Remove(stats);
            //    }
            //    foreach (var stats in Statistics.Where(x => x is StatisticsWarehouse))
            //    {
            //        Statistics.Remove(stats);
            //    }

            //    foreach (Location s in Shops)
            //    {                    
            //        Statistics.Add(((Shop)s.Building).MakeStatistics(timeStamp));
            //    }
            //    foreach (Location w in Warehouses)
            //    {
            //        Statistics.Add(((Warehouse)w.Building).MakeStatistics(timeStamp));
            //    }
            //}
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
                temp.InitialCost = cost;
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
            if (r != null)
            {
                Edges.Remove(r);
                return true;
            }
            return false;
        }
        public void AddNewBuilding(Location l)
        {
            if (l.Building is Warehouse)
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
            foreach (Cell c in Cells)
            {
                if (c.Index.Column == column && c.Index.Row == row)
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
            for (int col = shopLocation.Index.Column - shopLocation.Radius; col <= shopLocation.Index.Column + shopLocation.Radius; col++)
            {
                for (int row = shopLocation.Index.Row - shopLocation.Radius; row <= shopLocation.Index.Row + shopLocation.Radius; row++)
                {
                    Cell c = getCellByIndex(col, row);
                    if (c != null)
                    {
                        int distance;
                        if (Math.Abs(row - shopLocation.Index.Row) > Math.Abs(col - shopLocation.Index.Column))
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
            foreach (Cell c in Cells)
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
            return Cells;
        }

        /// <summary>
        /// Returns a specific location by the inputed LocationID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Location</returns>
        public Location GetLocationByID(int id)
        {
            foreach (Location l in Locations)
            {
                if (l.LocationID == id)
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
            foreach (Location loc in Locations)
            {
                if (loc.LocationPoint == l.LocationPoint)
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
            return Cells[rng.Next(0, NumberOfCells), rng.Next(0, NumberOfCells)];
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

        public List<Building> GetWarehouses()
        {
            return Locations.Select(v => v.Building).Where(v => v is Warehouse).ToList();
        }

        public Location getBuildingLocation(Building b)
        {
            foreach (Location l in locations)
            {
                if (l.Building == b)
                {
                    return l;
                }
            }
            return null;
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

                    e.InitialCost += 1;

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

        public void Delete()
        {
            // Bottom up approach
            Building.DeleteAll(Id);
            Road.DeleteAll(Id);
            Cell.DeleteAll(Id);
            // Finally delete the map
            string sql = "DELETE FROM MAPS" +
                        $" WHERE MapId = '{Id}'";
            DataBase.ExecuteNonQuery(sql);
        }

        public void Save()
        {
            // Insert the object itself with its current state into the DB.
            string sql;
            if (Id <= 0)
            {
                sql = "INSERT INTO MAPS (NumberOfCells, CellSize)" +
                  $"VALUES ('{NumberOfCells}', '{CellSize}'); SELECT last_insert_id();";
                int id = DataBase.ExecuteScalar(sql);
                // Assign the returned int (id) to the map.
                Id = id; // This way we can do a check to either insert or update in the form ourselves.
            }
            else
            {
                sql = "INSERT INTO MAPS (MapId, NumberOfCells, CellSize)" +
                     $"VALUES ('{Id}', '{NumberOfCells}', '{CellSize}');";
                DataBase.ExecuteScalar(sql);
            }
            Console.WriteLine(Id);
            // Save Cells
            foreach (Cell c in Cells)
            {
                c.Save(Id);
            }
            // Save Roads
            foreach (Road road in Edges)
            {
                road.Save(Id);
            }
        }

        public static Map Load(int mapId)
        {
            #region Map
            int numberOfCells = 0;
            int cellSize = 0;
            Map map = null;
            MySqlDataReader reader;
            string sql = $"SELECT * FROM MAPS WHERE MapId = {mapId}";
            try
            {
                reader = DataBase.ExecuteReader(sql);
                // Since we only load in one map we only need to call it on the reader.
                reader.Read();

                numberOfCells = reader.GetInt32(1);
                cellSize = reader.GetInt32(2);

                map = new Map(numberOfCells, cellSize);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DataBase.CloseConnection();
            }
            #endregion
            #region Cells
            Cell[,] cells = new Cell[numberOfCells, numberOfCells];
            sql = $"SELECT * FROM CELLS WHERE MapId = {mapId}";
            try
            {
                reader = DataBase.ExecuteReader(sql);
                if (reader != null)
                {
                    int rowIndex;
                    int columnIndex;
                    int demand;
                    int demandGrowthPerTick;
                    string discriminator;
                    int radius;
                    Cell c;
                    while (reader.Read())
                    {
                        rowIndex = reader.GetInt32(1);
                        columnIndex = reader.GetInt32(2);
                        demand = reader.GetInt32(3);
                        demandGrowthPerTick = reader.GetInt32(4);
                        discriminator = reader.IsDBNull(5) == false ? reader.GetString(5) : string.Empty;
                        radius = reader.IsDBNull(6) == false ? reader.GetInt32(6) : 0;
                        c = new Cell(columnIndex, rowIndex, demand);
                        if (discriminator.Contains("Location"))
                        {
                            c = map.ChangeCellIntoLocation(c, radius);
                            map.Locations.Add((Location)c);
                        }
                        // Assign the cell to its rightful position in the cell array.
                        cells[columnIndex, rowIndex] = c;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DataBase.CloseConnection();
            }
            map.Cells = cells;
            #endregion
            #region Roads
            sql = $"SELECT * FROM ROADS WHERE Location1MapId = {mapId} AND Location2MapId = {mapId}";
            try
            {
                reader = DataBase.ExecuteReader(sql);

                Location source;
                int sourceRowIndex;
                int sourceColumnIndex;
                Location destination;
                int destinationRowIndex;
                int destinationColumnIndex;
                int initialCost;

                while (reader.Read())
                {
                    sourceRowIndex = reader.GetInt32(1);
                    sourceColumnIndex = reader.GetInt32(2);
                    destinationRowIndex = reader.GetInt32(4);
                    destinationColumnIndex = reader.GetInt32(5);
                    initialCost = reader.GetInt32(6);
                    source = (Location)map.Cells[sourceColumnIndex, sourceRowIndex];
                    destination = (Location)map.Cells[destinationColumnIndex, destinationRowIndex];
                    map.Edges.Add(new Road(source, destination, initialCost));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DataBase.CloseConnection();
            }
            #endregion
            #region Buildings
            sql = $"SELECT * FROM BUILDINGS WHERE MapId = {mapId}";
            try
            {
                reader = DataBase.ExecuteReader(sql);

                Building building;
                int rowIndex;
                int columnIndex;
                string discriminator;
                int stock;
                int restockAmount;

                while (reader.Read())
                {
                    rowIndex = reader.GetInt32(1);
                    columnIndex = reader.GetInt32(2);
                    discriminator = reader.IsDBNull(3) == false ? reader.GetString(3) : string.Empty;
                    if (discriminator.Contains("Shop"))
                    {
                        stock = reader.GetInt32(4);
                        restockAmount = reader.GetInt32(5);
                        building = new Shop(stock, restockAmount);
                    }
                    else
                    {
                        building = new Warehouse();
                    }
                    ((Location)map.Cells[columnIndex, rowIndex]).Building = building;
                    map.AddNewBuilding(((Location)map.Cells[columnIndex, rowIndex]));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DataBase.CloseConnection();
            }
            #endregion
            map.Id = mapId;
            return map;
        }

        public void ReAssignMaxDemandAndGrowth()
        {
            int newMaxDemand = int.MinValue;
            int newMaxDemandGrowth = int.MinValue;
            foreach (Cell c in Cells)
            {
                if (c.Demand > newMaxDemand)
                {
                    newMaxDemand = c.Demand;
                }

                if (c.DemandGrow > newMaxDemandGrowth)
                {
                    newMaxDemandGrowth = c.DemandGrow;
                }
            }
            Cell.maxDemand = newMaxDemand;
            Cell.maxDemandGrow = newMaxDemandGrowth;
        }
    }
}
