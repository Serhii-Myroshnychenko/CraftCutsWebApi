using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class IdGetterRepository : IIdGetterRepository
    {
        private readonly DapperContext _dapperContext;
        public IdGetterRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> GetBarberIdByName(string name)
        {
            var query = "Select * from Barber where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var barber =await connection.QuerySingleOrDefaultAsync<Barber>(query, new { name });
                if (barber != null)
                {
                    return barber.Barber_id;
                }

                return 0;
            }
        }

        public async Task<int> GetCustomerIdByName(string email)
        {
            var query = "Select * from Customer where email = @email";

            using (var connection = _dapperContext.CreateConnection())
            {
                var cust = await connection.QuerySingleOrDefaultAsync<Customer>(query, new { email });
                if (cust != null)
                {
                    return cust.Customer_id;
                }

                return 0;
            }
        }
        public async Task<int> GetPromocodeIdByName(string name)
        {
            var query = "Select * from Promocode where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<Promocode>(query, new { name });
                if (id != null)
                {
                    return id.Promocode_id;
                }
                return 0;
            }
        }
        public async Task<int> GetServiceIdByName(string name)
        {
            var query = "Select * from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<Service>(query, new { name });
                if (id != null)
                {
                    return id.Service_id;
                }
                return 0;

            }
        }
        public async Task<decimal> GetPriceByName(string name)
        {
            var query = "Select * from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var service = await connection.QuerySingleOrDefaultAsync<Service>(query, new { name });
                if (service != null)
                {
                    return service.Price;
                }

                return 0;
            }
        }
    }
}
