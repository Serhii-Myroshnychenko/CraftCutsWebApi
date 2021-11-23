using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IBookingRepository
    {
        public Task CreateBooking(int barber_id, int customer_id, decimal price, DateTime date, bool is_paid, int? promocode_id);

        public Task<IEnumerable<Booking>> GetBookings();
        public Task<Booking> GetBooking(int id);
        public Task UpdateBooking(int id, Booking booking);
        public Task DeleteBooking(int id);


        public Task<IEnumerable<BookingCustomerList>> GetBookingsByCustomerId(int id);

    }
}
