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
    public class DemoBeardRepository : IDemoBeardRepository
    {
        private readonly DapperContext _context;
        public DemoBeardRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDemoBeard(string image_name, string displayed_name)
        {
            var query = "INSERT into DemoBeard (image_name,displayed_name) values (@image_name,@displayed_name)";
            var parameters = new DynamicParameters();
            parameters.Add("image_name", image_name, DbType.String);
            parameters.Add("displayed_name", displayed_name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<DemoBeard> GetDemoBeard(int id)
        {
            var query = "SELECT * FROM DemoBeard WHERE beard_id = @id";
            using (var connection = _context.CreateConnection())
            {
                var beard = await connection.QuerySingleOrDefaultAsync<DemoBeard>(query, new { id });
                return beard;

            }
        }

        public async Task<IEnumerable<DemoBeard>> GetDemoBeards()
        {
            var query = "SELECT * FROM DemoBeard";
            using (var connection = _context.CreateConnection())
            {
                var customers = await connection.QueryAsync<DemoBeard>(query);
                return customers.ToList();
            }
        }

    }
}
