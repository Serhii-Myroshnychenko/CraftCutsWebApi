using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Registration
    {
        [StringLength(70, MinimumLength = 2)]
        [Required]
        public string name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string password { get; set; }
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")]
        [Required]
        public string email { get; set; }
        [RegularExpression(@"(^+\d{1,2})?(((\d{3}))|(-?\d{3}-)|(\d{3}))((\d{3}-\d{4})|(\d{3}-\d\d-\d\d)|(\d{7})|(\d{3}-\d-\d{3}))")]
        public string phone { get; set; }
        public DateTime birthday { get; set; }

    }
}
