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
        private Map _map;
        private double _maxSold = 0;
        private List<Location> _initialWarehouses;
        private List<Location> _initialShops;
        private List<Location> _allPossibleLocations;
        private List<Location> _bestLocations;
        

        public BestPlacement(Map m)
        {
            _initialMap = m;
            _map = new Map(m.NumberOfLocations, m.NumberOfCells, m.CellSize);
            _initialWarehouses = new List<Location>();
            _initialShops = new List<Location>();
            _allPossibleLocations = new List<Location>();
            _bestLocations = new List<Location>();
            MakeBackups();
        }

        public void MakeBackups()
        {
            _initialMap.Warehouses.ForEach(x => _initialWarehouses.Add(x));
            _initialMap.Shops.ForEach(x => _initialShops.Add(x));

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
                    _initialMap.NextTick(i);
                }
                foreach (StatisticsShop stats in _initialMap.Statistics)
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
            _initialMap.ResetMap();
            _initialMap.RemoveAllBuildings();
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

        private void AddBuildings()
        {
            int shopPositionInArray = 0;
            int wareHousePositionInArray = 0;
            foreach (Location l in _initialMap.Locations)
            {
                if (l.LocationID == 1 || l.LocationID == 2)
                {
                    l.Building = _initialShops[shopPositionInArray].Building;
                    _initialMap.AddNewBuilding(l);
                    shopPositionInArray++;
                }
                else if (l.LocationID == 3)
                {
                    l.Building = _initialWarehouses[wareHousePositionInArray].Building;
                    _initialMap.AddNewBuilding(l);
                    wareHousePositionInArray++;
                }
            }
        }

        public void Reset()
        {
            //Reset the
        }

        public void yeet()
        {
            int shopPositionInArray = 0;
            int wareHousePositionInArray = 0;
            foreach (Location l in _map.Locations)
            {
                if(l.LocationID == 1 || l.LocationID == 2) {
                    l.Building = _shops[shopPositionInArray].Building;
                    _map.AddNewBuilding(l);
                    shopPositionInArray++;
                } else if (l.LocationID == 3)
                {
                    l.Building = _wareHouses[wareHousePositionInArray].Building;
                    _map.AddNewBuilding(l);
                    wareHousePositionInArray++;
                }
            }
        }


    }
}
