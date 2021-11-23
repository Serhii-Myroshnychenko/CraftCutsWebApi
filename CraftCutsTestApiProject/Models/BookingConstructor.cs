using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class BookingConstructor
    {
        [Required(ErrorMessage = "Введите имя барбера")]
        public string BarberName { get; set; }
        [Required(ErrorMessage = "Введите почту барбера")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Введите название услуги")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Введите дату")]
        public DateTime Date { get; set; }
        public string? PromocodeName { get; set; }
    }
}
