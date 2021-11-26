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
    public class BookingListRepository : IBookingListRepository
    {
        private readonly DapperContext _dapperContext;
        public BookingListRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateBookingList(int booking_id, int service_id)
        {
            var query = "INSERT INTO BookingList (booking_id,service_id) VALUES (@booking_id,@service_id)";
            var parameters = new DynamicParameters();
            parameters.Add("booking_id", booking_id, DbType.Int64);
            parameters.Add("service_id", service_id, DbType.Int64);
            

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
