using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Promocode
    {
        public int promocode_id { get; set; }
        public string name { get; set; }
        public int sale_percent { get; set; }
        public DateTime time { get; set; }
    }
}
