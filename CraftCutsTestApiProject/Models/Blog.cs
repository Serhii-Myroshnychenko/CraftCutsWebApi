using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Blog
    {
        public int blog_id { get; set; }
        public DateTime time_step { get; set; }
        public string title { get; set; }
        public string? blog_content { get; set; }
        public string picture_url { get; set; }


    }
}
