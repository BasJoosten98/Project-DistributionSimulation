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
        private double maxStored = 0;

        public BestPlacement(Map m)
        {
            _map = m;
        }

        public void MakeBackups()
        {
            //Back up the exisiting buildings

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
            //foreach
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


    }
}
