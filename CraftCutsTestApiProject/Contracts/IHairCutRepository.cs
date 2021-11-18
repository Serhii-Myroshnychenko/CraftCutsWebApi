using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IHairCutRepository
    {
        public Task<IEnumerable<HairCut>> GetHairCuts();
        public Task<HairCut> GetHairCut(int id);
        public Task AddHairCut(string image_name,string displayed_name);
    }
}
