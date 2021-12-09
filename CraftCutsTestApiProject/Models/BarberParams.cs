using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class BarberParams
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
    }
}
