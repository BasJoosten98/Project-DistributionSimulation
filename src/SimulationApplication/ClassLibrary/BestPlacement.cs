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

        }

        public void MakeBackups()
        {
            foreach (Location warehouse in _initialMap.Warehouses)
            {
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
            for (int i = 0; i < array.Length; i++)
            {
                if(i == 0)
                {
                    Location warehouseLocation = _initialMap.GetLocationByID(array[i]);
                    warehouseLocation.Building = _initialWarehouse.Building;
                    currentMap.AddNewBuilding(warehouseLocation);
                }
                else
                {
                    Location shopLocation = _initialMap.GetLocationByID(array[i]);
                    shopLocation.Building = _initialShops[i - 1].Building;
                    currentMap.AddNewBuilding(shopLocation);
                }
                
            }
            if(currentMap.Shops.Count > 0 && currentMap.Warehouses.Count > 0)
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
                                bestLocations = currentMap;
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


    }
}
