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
        private readonly IIdGetterRepository _idGetterRepository;
        public BarberController(IBarberRepository barberRepository, IIdGetterRepository idGetterRepository)
        {
            _barberRepository = barberRepository;
            _idGetterRepository = idGetterRepository;
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
        [HttpPost("BarberId")]
        public async Task<IActionResult> GetBarberIdByNameAsync([FromBody] BarberParams barberParams)
        {
            try
            {
                var id = await _idGetterRepository.GetBarberIdByName(barberParams.Name);
                if (id != 0)
                {
                    return Ok(id);
                }
                return NotFound("Такого барбера не существует");
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
        [HttpPost("Auth")]
        public async Task<IActionResult> Authorization([FromForm] AuthConstructor authConstructor)
        {
            try
            {
                var barber = await _barberRepository.Authorization(authConstructor);
                return Ok(barber);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
