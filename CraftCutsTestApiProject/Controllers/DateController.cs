using CraftCutsTestApiProject.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateRepository _dateRepository;
        private readonly IBarberRepository _barberRepository;
        public DateController(IDateRepository dateRepository, IBarberRepository barberRepository)
        {
            _dateRepository = dateRepository;
            _barberRepository = barberRepository;
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetBookingDatesAsync(int id)
        {
            try
            {
                var barber = await _barberRepository.GetBarber(id);
                if(barber != null)
                {
                    var dates = await _dateRepository.GetBookingDatesAsync(id);
                    return Ok(dates);
                }
                return NotFound("Такого барбера не существует");

                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
