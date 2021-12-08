using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IDateRepository
    {
        public Task<IEnumerable<Date>> GetBookingDatesAsync(int id);
    }
}
