using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Barber
    {
        public int Barber_id { get; }
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите имя фото")]
        public string Photo_name { get; set; }

    }
}
