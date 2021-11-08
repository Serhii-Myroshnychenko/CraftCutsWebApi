using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IBookingRepository
    {
        public Task CreateBooking(int barber_id, int customer_id, decimal price, DateTime date, bool is_paid, int promocode_id);
        public Task<int> GetBarberIdByName(string name);
        public Task<int> GetCustomerIdByName(string name);
        public Task<int> GetPromocodeIdByName(string name);
        public Task<decimal> GetPriceByName(string name);
        public Task<int> GetServiceIdByName(string name);
    }
}
