using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IBarberRepository
    {
        public Task<IEnumerable<Barber>> GetBarbers();
        public Task<Barber> GetBarber(int id);
        public Task CreateBarber(Barber barber);
        public Task DeleteBarber(int id);
        public Task<Barber> Authorization(AuthConstructor authConstructor);
    }
}
