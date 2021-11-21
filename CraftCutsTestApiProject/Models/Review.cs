using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Review
    {
        public int Review_id { get; set; }
        public int Customer_id { get; set; }
        public string Feedback { get; set; }
        public int Stars { get; set; }
    }
}
