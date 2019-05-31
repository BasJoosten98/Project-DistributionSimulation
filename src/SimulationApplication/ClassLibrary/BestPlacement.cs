using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class BestPlacement
    {
        private Map _initialMap;
        private double _maxSold = 0;
        private List<Building> _buildings;
        public List<int> bestMap;
        private ProgressBar _bar;
        private int _ticks;



        public BestPlacement(Map m, int ticks, ProgressBar bar)
        {
            //Takes a copy of the map, to run with the same configuration
            _initialMap = m;
            _ticks = ticks;
            _bar = bar;
            MakeBackups();
        }

        public void MakeBackups()
        {

            _buildings = new List<Building>();
            foreach (Location item in _initialMap.Shops)
            {
                _buildings.Add(item.Building);
            }
            foreach (Location item2 in _initialMap.Warehouses)
            {
                _buildings.Add(item2.Building);
            }

        }

        public void CheckBestPlacement(List<int> mapBuild)
        {
            _initialMap.RemoveAllBuildings();
            for (int i = 0; i < mapBuild.Count; i++)
            {
                if(mapBuild[i] != -1)
                {
                    _initialMap.Locations[i].Building = _buildings[mapBuild[i]];
                    _initialMap.AddNewBuilding(_initialMap.Locations[i]);
                }
            }
            _initialMap.PrepareForSimulation();
            foreach (Location l in _initialMap.Warehouses)
            {
                Warehouse w = (Warehouse)l.Building;

                for (int i = 1; i <= w.TotalVehiclesAtStart; i++)
                {
                    Vehicle temp = new Vehicle(new System.Windows.Forms.PictureBox());
                    w.AddVehicle(temp);
                }
            }
            for (int i = 0; i <= _ticks; i++)
            {
                _initialMap.NextTick(i);
            }
            double sum = 0;
            foreach (Statistics item in _initialMap.Statistics)
            {
                if(item.Time == _ticks)
                {
                    if(item is StatisticsShop)
                    {
                        StatisticsShop obj = (StatisticsShop)item;
                        sum += obj.AverageSold;
                    }
                }
            }
            if(sum > _maxSold)
            {
                _maxSold = sum;
                bestMap = mapBuild;
            }
            _initialMap.ResetMap();
            
        }
        
        public void CheckCombinations()
        {
            _bar.Visible = true;
            List<List<int>> combinations = createAllDifferentMaps(_initialMap.Shops.Count + _initialMap.Warehouses.Count, _initialMap.Locations.Count);
            _bar.Maximum = combinations.Count - 1;
            for (int i = 0; i < combinations.Count; i++)
            {
                CheckBestPlacement(combinations[i]);
                _bar.Value = i;
                _bar.Refresh();
            }
            _initialMap.RemoveAllBuildings();
            _bar.Visible = false;
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
            if (true)
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
        public List<List<int>> createAllDifferentMapsRec(int lastBuiding, int currentBuilding, List<int> currentMap)
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

        public List<int> GetBestBuild()
        {
            return bestMap;
        }

        public List<Building> GetBuildings()
        {
            return _buildings;
        }
    }

    
}
