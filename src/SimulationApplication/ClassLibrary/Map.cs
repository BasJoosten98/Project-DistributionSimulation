using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
	public class Map
	{
        
        public int Length { get; }
        public int Width { get; }
        public List<Location> Locations { get; private set; }

        public Map()
        {
            
            Locations = new List<Location>();
            
        }

        public void AddLocation(Location location)
        {
            //TODO: Restrict this to agreed canvas size
            Locations.Add(location);
 
        }
        
        

        public Location GetLocation(int locationID)
        {
            foreach (Location item in Locations)
            {
                if(item.LocationID == locationID)
                {
                    return item;
                }
            }
            return null;
        }

        public void PlaceBuilding(int locationID)
        {
            Location l = GetLocation(locationID);
            l.Building = new Shop();

        }
	}
}
