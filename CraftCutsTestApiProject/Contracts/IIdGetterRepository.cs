using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IIdGetterRepository
    {
        public Task<int> GetBarberIdByName(string name);
        public Task<int> GetCustomerIdByName(string name);
        public Task<int> GetPromocodeIdByName(string name);
        public Task<decimal> GetPriceByName(string name);
        public Task<int> GetServiceIdByName(string name);
        public Task<int> GetBookingIdByParams(int barber_id,int customer_id,decimal price,DateTime date);
    }
}
