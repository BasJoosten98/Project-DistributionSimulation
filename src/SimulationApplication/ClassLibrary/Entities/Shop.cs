using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Shop : Building
    {
        public int Stock { get; set; }
        public int RestockAmount { get; set; }
    }
}
