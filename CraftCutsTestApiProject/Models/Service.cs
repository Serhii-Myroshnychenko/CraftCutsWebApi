using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    
        public class Service
        {
            public int service_id { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public string description { get; set; }
        }
    
}
