using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class ReviewConstructor
    {
        [Required(ErrorMessage = "Что-то не так с айди")]
        public int Customer_id { get; set; }
        [Required(ErrorMessage = "Введите отзыв")]
        public string Feedback { get; set; }
        [Required(ErrorMessage = "Выберите звёзды")]
        public int Stars { get; set; }
    }
}
