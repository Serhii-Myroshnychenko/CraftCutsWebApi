﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Promocode
    {
        public int Promocode_id { get; set; }
        public string Name { get; set; }
        public int Sale_percent { get; set; }
        public DateTime Time { get; set; }
    }
}
