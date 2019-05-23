using System.Collections.Generic;

namespace ClassLibrary.Entities
{
    public class Map
    {
        public int Id { get; set; }
        public int NumberOfCells { get; set; }
        public int CellSize { get; set; }
        public List<Cell> Cells { get; set; }
        public List<Road> Roads { get; set; }
    }
}
