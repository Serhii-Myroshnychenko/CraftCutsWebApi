using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Admin
    {
        public int Admin_id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] //должны использоваться только буквы; первая буква должна быть прописной; Пробелы разрешены, а цифры и специальные символы — нет.
        [StringLength(70, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
