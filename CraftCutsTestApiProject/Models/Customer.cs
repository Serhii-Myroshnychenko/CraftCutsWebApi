using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }

    }
}
