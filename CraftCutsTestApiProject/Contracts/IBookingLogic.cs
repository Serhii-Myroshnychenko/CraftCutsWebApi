using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IBookingLogic
    {
        public Task<string> CreateBookingLogic(BookingConstructor bookingConstructor);
    }
}
