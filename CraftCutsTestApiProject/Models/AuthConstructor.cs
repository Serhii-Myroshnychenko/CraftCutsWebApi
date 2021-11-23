using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class AuthConstructor
    {
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

    }
}
