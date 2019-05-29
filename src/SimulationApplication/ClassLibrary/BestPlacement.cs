using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BestPlacement
    {
        private Map _initialMap;
        private double _maxSold = 0;
        private Location _initialWarehouse;
        private List<Location> _initialShops;
        public Map bestLocations;
        int[] allPossibleCombinations;
        

        public BestPlacement(Map m)
        {
            //Takes a copy of the map, to run with the same configuration
            _initialMap = m;
            _initialShops = new List<Location>();
            allPossibleCombinations = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //This should be the count of the list
            MakeBackups();
            createAllDifferentMaps(5, 5);
        }

        public void MakeBackups()
        {
            //Je moet backups maken van de buildings, NIET van de locaties EN DIT ZIJN REFERENCIES!!!
            foreach (Location warehouse in _initialMap.Warehouses)
            {
                //Dit werkt niet!! Geen copy van de locatie, maar een reference
                _initialWarehouse = _initialMap.Warehouses[0];
                _initialWarehouse.Building = warehouse.Building;
                
            }
            foreach (Location shop in _initialMap.Shops)
            {
                Location l = new Location(shop.LocationID,shop.Index.Column, shop.Index.Row);
                l.Building = shop.Building;
                _initialShops.Add(l);
            }

        }

        public void CheckBestPlacement(int[] array)
        {
            //STEP 1:
            //TODO: Regenerate the different possible locations in a map
            Map currentMap = new Map(_initialMap.NumberOfLocations, _initialMap.NumberOfCells, _initialMap.CellSize);
            //Intend to change to location with by getting the first int in the array, representing warehouses.
            for (int i = 0; i < array.Length; i++) //place buildings on map
            {
                if(i == 0)//warehouse location number
                {
                    Location warehouseLocation = _initialMap.GetLocationByID(array[i]);
                    warehouseLocation.Building = _initialWarehouse.Building; //2 locaties bezitten dezelfde warehouse nu!!

                    currentMap.AddNewBuilding(warehouseLocation);
                }
                else //shop location number
                {
                    Location shopLocation = _initialMap.GetLocationByID(array[i]);
                    shopLocation.Building = _initialShops[i - 1].Building;
                    currentMap.AddNewBuilding(shopLocation);
                }
                
            }
            if(currentMap.Shops.Count > 0 && currentMap.Warehouses.Count > 0) //why do you check this???
            {
                currentMap.PrepareForSimulation();
                for (int i = 0; i <= 50; i++)
                {
                    currentMap.NextTick(i);
                }
                foreach (Statistics obj in currentMap.Statistics)
                {
                    if (obj.Time == 50)
                    {
                        if (obj is StatisticsShop)
                        {
                            StatisticsShop shopStats = (StatisticsShop)obj;
                            if (shopStats.AverageSold > _maxSold)
                            {
                                _maxSold = shopStats.AverageSold;
                                bestLocations = currentMap; //current map is geen copy, maar een referentie!! Het slaat dus niet op!!
                            }
                        }
                        if (obj is StatisticsWarehouse)
                        {

                        }

                    }
                }
                bestLocations = currentMap;
            }
            
            //STEP 2:
            //for loop, 50, check the best place, reset i. 
            //store stastics 
            //_map.Statistics,
            //_map.Locations,
            //_map.NextTick(i)
            
            //STEP 3: 
            //loop finished
            //check the statistics list
            //_map.Statistics
            //get all the statistics objects with timestamp == 50
            //get the MAX average sold, if bigger then previous, store it.
            //save the placements of the buildings
            
        }

        public void CheckCombinations()
        {
            int[] data = new int[3];
            int[] arr = allPossibleCombinations;
            int nodes = 3;
            CombinationUtil(arr, data, 0, arr.Length - 1, 0, nodes);
        }

        private void CombinationUtil(int[] arr, int[] data, int start, int end, int index, int nodes)
        {
            int[] combination = new int[3];
            //Current combination is ready to be checked when the index == 3
            //check the best placement when a combination is generated
            if(index == nodes)
            {
                for (int i = 0; i < nodes; i++)
                {
                    combination[i] = data[i];
                    Console.Write(data[i] + " ");
                }
                Console.WriteLine("");
                CheckBestPlacement(combination);
                return;
            }

            for (int i = start; i <= end &&
                      end - i + 1 >= nodes - index; i++)
            {
                data[index] = arr[i];
                CombinationUtil(arr, data, i + 1,
                                end, index + 1, nodes);
            }
        }


        public void Reset()
        {
            //Reset the
        }

        public void GetAllCombinations(List<int> list)
        {

        }

        private List<List<int>> createAllDifferentMaps(int totalBuidings, int totalLocations)
        {
            Console.WriteLine("Start of difmaps");
            if (totalBuidings > totalLocations) { throw new Exception("Not possible"); }
            List<int> temp = new List<int>();
            for (int i = 1; i <= totalLocations; i++)
            {
                temp.Add(-1);
            }
            List<List<int>> result = createAllDifferentMapsRec(totalBuidings - 1, 0, temp);
            if (false)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    string holder = "";
                    for (int j = 0; j < result[i].Count; j++)
                    {
                        holder += " " + result[i][j];
                    }
                    Console.WriteLine(holder);
                }
            }
            Console.WriteLine("End of difmaps");
            return result;
        }
        private List<List<int>> createAllDifferentMapsRec(int lastBuiding, int currentBuilding, List<int> currentMap)
        {
            List<List<int>> endResults = new List<List<int>>();
            if (currentBuilding > lastBuiding)
            {
                endResults.Add(currentMap);
                return endResults;
            }
           
            int skippedPos = 0;
            bool emptyLocationFound = false;
            for (int skipPos = 0; skipPos >= 0; skipPos++)
            {
                emptyLocationFound = false;
                skippedPos = 0;
                for (int i = 0; i < currentMap.Count; i++)
                {
                    if (currentMap[i] == -1 && skippedPos == skipPos) //empty location
                    {
                        List<int> temp = new List<int>();
                        foreach (int k in currentMap) { temp.Add(k); }
                        temp[i] = currentBuilding;

                        List<List<int>> results = createAllDifferentMapsRec(lastBuiding, currentBuilding + 1, temp);
                        for (int j = 0; j < results.Count; j++)
                        {
                            endResults.Add(results[j]);
                        }
                        skippedPos++;
                        emptyLocationFound = true;
                        break;
                    }
                    else if(currentMap[i] == -1 && skippedPos < skipPos)
                    {
                        skippedPos++;
                    }
                }
                if (!emptyLocationFound)
                {
                    break;
                }
            }
            return endResults;
        }
    }
}
