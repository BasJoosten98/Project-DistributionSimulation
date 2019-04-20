using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Events
{
    public class LowStockReachedEventArgs :  EventArgs
    {
        public DateTime TimeReached { get; set; }
    }
}
                