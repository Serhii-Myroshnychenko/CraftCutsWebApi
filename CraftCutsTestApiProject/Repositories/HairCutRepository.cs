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
    public class HairCutRepository : IHairCutRepository
    {
        private readonly DapperContext _context;
        public HairCutRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<HairCut> GetHairCut(int id)
        {
            var query = "SELECT * FROM HairCut WHERE haircut_id = @id";
            using (var connection = _context.CreateConnection())
            {
                var haircut = await connection.QuerySingleOrDefaultAsync<HairCut>(query, new { id });
                return haircut;

            }
        }

        public async Task<IEnumerable<HairCut>> GetHairCuts()
        {
            var query = "Select * FROM HairCut";
            using (var connection = _context.CreateConnection())
            {
                var hairCuts = await connection.QueryAsync<HairCut>(query);
                return hairCuts.ToList();
            }
        }
        public async Task AddHairCut(byte[] image_data, string displayed_name)
        {
            var query = "INSERT into HairCut (image_data,displayed_name) values (@image_data,@displayed_name)";
            var parameters = new DynamicParameters();
            parameters.Add("image_data", image_data, DbType.Binary);
            parameters.Add("displayed_name", displayed_name, DbType.String);
        
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
