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
        public Map map;
        private double _maxSold = 0;
        private List<Location> _initialWarehouses;
        private List<Location> _initialShops;
        private List<Location> _allPossibleLocations;
        private List<Location> _bestLocations;
        

        public BestPlacement(Map m)
        {
            _initialMap = m;
            //Takes a copy of the map, to run with the same configuration
            map = new Map(m.NumberOfLocations, m.NumberOfCells, m.CellSize);
            _initialWarehouses = new List<Location>();
            _initialShops = new List<Location>();
            _allPossibleLocations = new List<Location>();
            _bestLocations = new List<Location>();
            MakeBackups();

        }

        public void MakeBackups()
        {
            foreach (Location warehouse in _initialMap.Warehouses)
            {
                Location l = new Location(warehouse.LocationID,warehouse.Index.Column, warehouse.Index.Row);
                l.Building = warehouse.Building;
                _initialWarehouses.Add(l);
            }
            foreach (Location shop in _initialMap.Shops)
            {
                Location l = new Location(shop.LocationID,shop.Index.Column, shop.Index.Row);
                l.Building = shop.Building;
                _initialShops.Add(l);
            }

        }

        public void RearrangeBuildings()
        {
            //map.addbuilding
        }

        public void CheckBestPlacement()
        {
           
            //TODO: Regenerate the different possible locations in a map

            foreach (Location item in _allPossibleLocations)
            {
                for (int i = 0; i < 50; i++)
                {
                    map.NextTick(i);
                }
                foreach (StatisticsShop stats in map.Statistics)
                {
                    if (stats.Time == 50)
                    {
                        if (stats.AverageSold > _maxSold)
                        {
                            _maxSold = stats.AverageSold;
                            _bestLocations = _initialMap.Shops.Concat(_initialMap.Warehouses).ToList();
                            
                        }
                    }
                }
            }
            map.ResetMap();
            map.RemoveAllBuildings();
            AddBuildings();
            
            
            //for loop, 50, check the best place, reset i. 
            //store stastics 

            //_map.Statistics,
            //_map.Locations,
            //_map.NextTick(i)
            
            //loop finished
            //check the statistics list
            //_map.Statistics
            //get all the statistics objects with timestamp == 50
            //get the MAX average sold, if bigger then previous, store it.
            //save the placements of the buildings
            //
            
        }

        public void AddBuildings()
        {
            int shopPositionInArray = 0;
            int wareHousePositionInArray = 0;
            foreach (Location l in map.Locations)
            {
                if (l.LocationID == 1 || l.LocationID == 2)
                {
                    l.Building = _initialShops[shopPositionInArray].Building;
                    map.AddNewBuilding(l);
                    shopPositionInArray++;
                }
                else if (l.LocationID == 3)
                {
                    l.Building = _initialWarehouses[wareHousePositionInArray].Building;
                    map.AddNewBuilding(l);
                    wareHousePositionInArray++;
                }
            }
        }

        public void Reset()
        {
            //Reset the
        }


    }
}
