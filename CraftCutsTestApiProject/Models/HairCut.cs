using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class HairCut
    {
        public int Haircut_id { get; }
        [Required(ErrorMessage = "Введите имя изображения")]
        public string Image_name { get; set; }
        public string? Displayed_name { get; set; }

    }
}
