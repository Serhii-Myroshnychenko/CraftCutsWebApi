﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class HairCut
    {
        public int haircut_id { get; set; }
        public byte[] image_data { get; set; }
        public string? displayed_name { get; set; }

    }
}
