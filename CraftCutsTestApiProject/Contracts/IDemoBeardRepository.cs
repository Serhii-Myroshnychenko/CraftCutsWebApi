using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IDemoBeardRepository
    {
        public Task<IEnumerable<DemoBeard>> GetDemoBeards();
        public Task<DemoBeard> GetDemoBeard(int id);
        public Task CreateDemoBeard(string image_name, string displayed_name);

    }
}
