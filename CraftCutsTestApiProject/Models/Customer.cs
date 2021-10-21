using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string password { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }

    }
}
