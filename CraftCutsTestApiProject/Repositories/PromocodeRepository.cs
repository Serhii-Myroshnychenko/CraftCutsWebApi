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
    public class PromocodeRepository : IPromocodeRepository
    {
        private readonly DapperContext _dapperContext;
        public PromocodeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task DeletePromocode(int id)
        {
            var query = "DELETE FROM Promocode WHERE promocode_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Promocode> GetPromocode(int id)
        {
            var query = "SELECT * FROM Promocode Where promocode_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var promocode = await connection.QuerySingleOrDefaultAsync<Promocode>(query, new { id });
                return promocode;
            }
        }

        public async Task<Promocode> GetPromocodeByName(string name)
        {
            var query = "SELECT * FROM Promocode Where name = @name";
            using (var connection = _dapperContext.CreateConnection())
            {
                var promocode = await connection.QuerySingleOrDefaultAsync<Promocode>(query, new { name});
                return promocode;
            }
        }

        public async Task<IEnumerable<Promocode>> GetPromocodes()
        {
            var query = "SELECT * FROM Promocode";
            using (var connection = _dapperContext.CreateConnection())
            {
                var promocodes = await connection.QueryAsync<Promocode>(query);
                return promocodes.ToList();
            }
        }
    }
}
