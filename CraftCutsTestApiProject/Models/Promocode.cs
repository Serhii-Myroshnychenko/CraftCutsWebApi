using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Promocode
    {
        public int Promocode_id { get;  }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите проценты")]
        public int Sale_percent { get; set; }
        [Required(ErrorMessage = "Введите время")]
        public DateTime Time { get; set; }
    }
}
