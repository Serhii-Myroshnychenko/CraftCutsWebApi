using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Blog
    {
        public int Blog_id { get; }
        [Required(ErrorMessage = "Введите дату")]
        public DateTime Time_step { get; set; }
        [Required(ErrorMessage = "Введите заглавие")]
        public string Title { get; set; }
        public string? Blog_content { get; set; }
        [Required(ErrorMessage = "Введите путь картинки")]
        public string Picture_url { get; set; }


    }
}
