using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class BookingList
    {
        [Required(ErrorMessage = "Введите booking_id")]
        public int Booking_id { get; set; }
        [Required(ErrorMessage = "Введите service_id")]
        public int Service_id { get; set; }
    }
}
