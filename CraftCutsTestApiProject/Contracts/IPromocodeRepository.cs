using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IPromocodeRepository
    {
        public Task<IEnumerable<Promocode>> GetPromocodes();
        public Task<Promocode> GetPromocode(int id);
        public Task DeletePromocode(int id);
        
    }
}
