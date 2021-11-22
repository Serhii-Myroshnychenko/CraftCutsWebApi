using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Blog
    {
        public int Blog_id { get; set; }
        public DateTime Time_step { get; set; }
        public string Title { get; set; }
        public string? Blog_content { get; set; }
        public string Picture_url { get; set; }


    }
}
