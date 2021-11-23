using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{

    public class Service
    {
        public int Service_id { get; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
    }
}
