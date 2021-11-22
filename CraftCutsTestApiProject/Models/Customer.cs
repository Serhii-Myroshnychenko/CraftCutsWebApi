using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Customer
    {
        public int Customer_id { get; set; }

        [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")] //должны использоваться только буквы; первая буква должна быть прописной; Пробелы разрешены, а цифры и специальные символы — нет.

        [StringLength(70, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]

        public string Password { get; set; }
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")]
        [Required]
        public string Email { get; set; }
        [RegularExpression(@"(^+\d{1,2})?(((\d{3}))|(-?\d{3}-)|(\d{3}))((\d{3}-\d{4})|(\d{3}-\d\d-\d\d)|(\d{7})|(\d{3}-\d-\d{3}))")]

        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

    }
}

