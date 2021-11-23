using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Customer
    {
        public int Customer_id { get;  }

        [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")] //должны использоваться только буквы; первая буква должна быть прописной; Пробелы разрешены, а цифры и специальные символы — нет.

        [StringLength(70, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        [Required(ErrorMessage = "Введите пароль")]

        public string Password { get; set; }
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$")]
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set; }
        [RegularExpression(@"(^+\d{1,2})?(((\d{3}))|(-?\d{3}-)|(\d{3}))((\d{3}-\d{4})|(\d{3}-\d\d-\d\d)|(\d{7})|(\d{3}-\d-\d{3}))")]
        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime Birthday { get; set; }

    }
}

