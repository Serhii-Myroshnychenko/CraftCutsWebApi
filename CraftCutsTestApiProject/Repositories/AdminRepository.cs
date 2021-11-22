using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DapperContext _context;
        public AdminRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateAdmin(Admin adm)
        {
            var query = "INSERT INTO Admin (name,login,password) VALUES (@name,@login,@password)";
            var parameters = new DynamicParameters();
            parameters.Add("name", adm.Name, DbType.String);
            parameters.Add("login", adm.Login, DbType.String);
            parameters.Add("password", adm.Password, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            var query = "SELECT * FROM Admin";
            using (var connection = _context.CreateConnection())
            {
                var admins = await connection.QueryAsync<Admin>(query);
                return admins.ToList();
            }
        }
        
    }
}
