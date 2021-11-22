using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Registration
    {
        [StringLength(70, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя")]
        
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")]
        [Required(ErrorMessage = "Введите почту")]
        
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

    }
}
