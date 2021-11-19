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
        
        public string name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        [Required(ErrorMessage = "Введите пароль")]
        public string password { get; set; }
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")]
        [Required(ErrorMessage = "Введите почту")]
        
        public string email { get; set; }
        [Phone]
        [Required]
        public string phone { get; set; }
        public DateTime birthday { get; set; }

    }
}
