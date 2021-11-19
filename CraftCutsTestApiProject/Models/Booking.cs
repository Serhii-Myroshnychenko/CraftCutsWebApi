using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class Booking
    {
        public int booking_id { get; set; }
        public int barber_id { get; set; }
        public int customer_id { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
        public bool is_paid { get; set; }
        public int? promocode_id { get; set; }

    }
}
