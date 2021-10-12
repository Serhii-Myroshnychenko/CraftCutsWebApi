using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Admin
    {
        public int admin_id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
