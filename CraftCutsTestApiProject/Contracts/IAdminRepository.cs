using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<Admin>> GetAdmins();
        public Task CreateAdmin(Admin adm);
    }
}
