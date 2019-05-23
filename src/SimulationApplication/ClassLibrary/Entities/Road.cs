using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    /// <summary>
    /// Road connects two locations within a specific map with 
    /// a travel cost equal to initial cost.
    /// </summary>
    public class Road
    {
        public Map Map { get; set; }
        public Location Location1 { get; set; }
        public Location Location2 { get; set; }
        public int InitialCost { get; set; }

        // Foreign Key
        public int MapId { get; set; }
        public int Location1Id { get; set; }
        public int Location2Id { get; set; }

        public override string ToString()
        {
            return $"MapId: {MapId}, location 1 id: {Location1Id}, location 2 id: {Location2Id}, cost: {InitialCost}";
        }
    }
}
