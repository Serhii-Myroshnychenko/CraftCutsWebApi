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
        public async Task CreateBooking(int barber_id,int customer_id,decimal price,DateTime date,bool is_paid,int? promocode_id)
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
        public int GetBarberIdByName(string name)
        {
            var query = "Select * from Barber where name = @name";
            
            using (var connection = _dapperContext.CreateConnection())
            {
                var barber =  connection.QuerySingleOrDefault<Barber>(query, new { name });
                if (barber != null)
                {
                    return barber.barber_id;
                }

                return 0;
            }
        }
        
        public int GetCustomerIdByName(string email)
        {
            var query = "Select * from Customer where email = @email";

            using (var connection = _dapperContext.CreateConnection())
            {
                var cust =  connection.QuerySingleOrDefault<Customer>(query, new { email });
                if (cust != null)
                {
                    return cust.customer_id;
                }

                return 0;
            }
        }
        public int GetPromocodeIdByName(string name)
        {
            var query = "Select * from Promocode where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id =  connection.QuerySingleOrDefault<Promocode>(query, new { name });
                if (id != null)
                {
                    return id.promocode_id;
                }
                return 0;
            }
        }
        public int GetServiceIdByName(string name)
        {
            var query = "Select * from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = connection.QuerySingleOrDefault<Service>(query, new { name });
                if (id != null)
                {
                    return id.service_id;
                }
                return 0;

            }
        }
        public decimal GetPriceByName(string name)
        {
            var query = "Select * from Service where name = @name";

            using (var connection = _dapperContext.CreateConnection())
            {
                var service =  connection.QuerySingleOrDefault<Service>(query, new { name });
                if(service != null)
                {
                    return service.price;
                }

                return 0;
            }
        }
        
        
    }
}
