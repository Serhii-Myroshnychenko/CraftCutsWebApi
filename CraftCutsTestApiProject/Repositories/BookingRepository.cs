using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _dapperContext;
        public BookingRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateBooking(int barber_id,int customer_id,decimal price,DateTime date,bool is_paid,int promocode_id)
        {
            var query = "INSERT INTO Booking (barber_id,customer_id,price,date,is_paid,promocode_id) VALUES (@barber_id,@customer_id,@price,@date,@is_paid,@promocode_id)";
            var parameters = new DynamicParameters();
            parameters.Add("barber_id", barber_id, DbType.Int64);
            parameters.Add("customer_id", customer_id, DbType.Int64);
            parameters.Add("price",price, DbType.Decimal);
            parameters.Add("date", date, DbType.DateTime);
            parameters.Add("is_paid", is_paid, DbType.Boolean);
            parameters.Add("promocode_id", promocode_id, DbType.Int64);


            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<int> GetBarberIdByName(string name)
        {
            var query = "Select barber_id from Barber where name = @name";
            
            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync(query, new { name });
                return id;

            }
        }
        public async Task<int> GetCustomerIdByName(string email)
        {
            var query = "Select customer_id from Customer where email = @email";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync(query, new { email });
                return id;

            }
        }
        public async Task<int> GetPromocodeIdByName(string name)
        {
            var query = "Select promocode_id from Promocode where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync(query, new { name });
                return id;

            }
        }
        public async Task<int> GetServiceIdByName(string name)
        {
            var query = "Select service_id from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync(query, new { name });
                return id;

            }
        }
        public async Task<decimal> GetPriceByName(string name)
        {
            var query = "Select price from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var price = await connection.QuerySingleOrDefaultAsync(query, new { name });
                return price;

            }
        }
        
    }
}
