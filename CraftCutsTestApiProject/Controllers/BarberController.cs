using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
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
    public class BarberController : ControllerBase
    {
        private readonly IBarberRepository _barberRepository;
        public BarberController(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBarbers()
        {
            try
            {
                var barbers = await _barberRepository.GetBarbers();
                return Ok(barbers);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarber(int id)
        {
            try
            {
                var barber = await _barberRepository.GetBarber(id);
                if (barber != null)
                {
                    return Ok(barber);
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBarber([FromForm]Barber barber)
        {
            try
            {
                await _barberRepository.CreateBarber(barber);
                return Ok("Ok");

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            try
            {
                await _barberRepository.DeleteBarber(id);
                return Ok("Ok");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
