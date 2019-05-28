using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BestPlacement
    {
        private Map _map;
        private int timeStamp = 0;
        private double _maxSold = 0;
        private List<Location> _wareHouses;
        private List<Location> _shops;
        private List<Location> _allPossibleLocations;
        private List<Location> _bestLocations;

        public BestPlacement(Map m)
        {
            _map = m;
            _wareHouses = new List<Location>();
            _shops = new List<Location>();
            _allPossibleLocations = new List<Location>();
        }

        public void MakeBackups()
        {
            _map.Warehouses.ForEach(x => _wareHouses.Add(x));
            _map.Shops.ForEach(x => _shops.Add(x));

        }

        public void RemoveAllBuildings()
        {
            //remove
            //map.remove
        }

        public void RearrangeBuildings()
        {
            //map.addbuilding
        }

        public void CheckBestPlacement()
        {
            Map map = _map;
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
                            _bestLocations = map.Locations;
                        }
                    }
                }
            }
            
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
