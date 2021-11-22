using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Booking
    {
        public int Booking_id { get; set; }
        public int Barber_id { get; set; }
        public int Customer_id { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public bool Is_paid { get; set; }
        public int? Promocode_id { get; set; }

    }
}
