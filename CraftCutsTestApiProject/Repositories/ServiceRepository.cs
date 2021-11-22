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
    public class ServiceRepository: IServiceRepository
    {
        private readonly DapperContext _context;
        public ServiceRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetServices()
        {
            var query = "SELECT * FROM Service";
            using(var connection = _context.CreateConnection())
            {
                var services = await connection.QueryAsync<Service>(query);
                return services.ToList();
            }
        }

        public async Task<Service> GetService(int id)
        {
            var query = "SELECT * FROM Service WHERE service_id = @id";
            using (var connection = _context.CreateConnection())
            {
                var service = await connection.QuerySingleOrDefaultAsync<Service>(query, new { id });
                return service;
            }
        }

        public async Task CreateService(Service service)
        {
            var query = "INSERT INTO Service (name,price,description) VALUES (@name,@price,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("name", service.Name, DbType.String);
            parameters.Add("price", service.Price, DbType.Decimal);
            parameters.Add("description", service.Description, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task UpdateService(int id, Service service)
        {
            var query = "UPDATE Service SET name = @name, price = @price, description = @description WHERE service_id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("name", service.Name, DbType.String);
            parameters.Add("price", service.Price, DbType.Decimal);
            parameters.Add("description", service.Description, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteService(int id)
        {
            var query = "DELETE FROM Service WHERE service_id = @id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
