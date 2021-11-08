using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class BookingConstructor
    {
        public string BarberName { get; set; }
        public string CustomerEmail { get; set; }
        public string ServiceName { get; set; }
        public DateTime date { get; set; }
        public string? PromocodeName { get; set; }
    }
}
