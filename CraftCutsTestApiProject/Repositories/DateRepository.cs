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
    public class DateRepository : IDateRepository
    {
        private readonly DapperContext _dapperContext;
        public DateRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<Date>> GetBookingDatesAsync(int id)
        {
            var query = "DECLARE @StartDate smalldatetime, @EndDate smalldatetime SELECT @StartDate = Convert(smalldatetime,dateadd(HOUR, +2, (SELECT DATEADD(hour, DATEDIFF(hour, 0, getdate()), 0)     ))) , @EndDate = Convert(smalldatetime,dateadd(day, +7, @StartDate)); WITH ListDates(AllDates) AS (    SELECT @StartDate AS smalldatetime    UNION ALL    SELECT DATEADD(HOUR,1,AllDates)    FROM ListDates     WHERE AllDates < @EndDate ) SELECT AllDates FROM ListDates where AllDates not in (select Booking.date from Booking where barber_id = @id) and AllDates not in (select Convert(smalldatetime,dateadd(HOUR, +1, Booking.date)) from Booking where barber_id = @id ) and DATEPART(HOUR,AllDates) not in (0,1,2,3,4,5,6,7,19,20,21,22,23) option (maxrecursion 0) ";

            using(var connection = _dapperContext.CreateConnection())
            {
                var dates = await connection.QueryAsync<Date>(query, new { id });
                return dates;
            }

        }
    }
}
