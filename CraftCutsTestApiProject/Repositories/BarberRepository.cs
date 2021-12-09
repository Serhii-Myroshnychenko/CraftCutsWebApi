using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace CraftCutsTestApiProject.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DapperContext _dapperContext;

        public BarberRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateBarber(Barber barber)
        {
            var query = "INSERT INTO Barber (email,name,password,photo_name) values (@email,@name,@password,@photo_name);";
            var parameters = new DynamicParameters();
            parameters.Add("email", barber.Email, DbType.String);
            parameters.Add("name", barber.Name, DbType.String);
            parameters.Add("password", barber.Password, DbType.String);
            parameters.Add("photo_name", barber.Photo_name, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBarber(int id)
        {
            var query = "DELETE FROM Barber WHERE barber_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Barber> GetBarber(int id)
        {
            var query = "SELECT * FROM Barber Where barber_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var barber = await connection.QuerySingleOrDefaultAsync<Barber>(query, new { id });
                return barber;
            }
        }

        public async Task<IEnumerable<Barber>> GetBarbers()
        {
            var query = "SELECT * FROM Barber";
            using (var connection = _dapperContext.CreateConnection())
            {
                var barbers = await connection.QueryAsync<Barber>(query);
                return barbers.ToList();
            }
        }
        public async Task<Barber> Authorization(AuthConstructor authConstructor)
        {
            var query = "SELECT * FROM Barber WHERE password = @password AND email = @email";
            var parameters = new DynamicParameters();
            parameters.Add("password", authConstructor.Password, DbType.String);
            parameters.Add("email", authConstructor.Email, DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                var barber = await connection.QuerySingleOrDefaultAsync<Barber>(query, parameters);
                return barber;
            }
        }

    }
}
