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
    public class DemoBeardRepository : IDemoBeardRepository
    {
        private readonly DapperContext _context;
        public DemoBeardRepository(DapperContext context)
        {
            _context = context;
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
