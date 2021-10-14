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
        
    }
}
