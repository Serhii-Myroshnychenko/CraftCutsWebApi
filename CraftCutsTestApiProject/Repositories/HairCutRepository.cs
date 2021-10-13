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
        public async Task<IEnumerable<HairCut>> GetHairCuts()
        {
            var query = "SELECT * FROM HairCut";
            using (var connection = _context.CreateConnection())
            {
                var haircut = await connection.QueryAsync<HairCut>(query);
                return haircut.ToList();
            }
        }
    }
}
