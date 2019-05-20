using System.Collections.Generic;

namespace ClassLibrary.Entities
{
    public class Map
    {
        public int Id { get; set; }
        public int NumberOfCells { get; set; }
        public int CellSize { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
