﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Location : Cell
    {
        public int Radius { get; set; }
        public Building Building { get; set; }
    }
}