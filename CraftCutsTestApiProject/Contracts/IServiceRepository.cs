using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IServiceRepository
    {
        public Task<IEnumerable<Service>> GetServices();
        public Task<Service> GetService(int id);
        public Task CreateService(Service service);
        public Task UpdateService(int id, Service service);
        public Task DeleteService(int id);
        public Task<decimal> GetServicePriceByName(string name);
    }
}
