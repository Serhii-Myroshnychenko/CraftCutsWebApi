using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController: ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                var services = await _serviceRepository.GetServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            try
            {
                var service = await _serviceRepository.GetService(id);
                if (service == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(service);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("GetPrice")]
        public async Task<IActionResult> GetPriceByName(string name)
        {
            try
            {
                decimal price = await _serviceRepository.GetServicePriceByName(name);
                return Ok(price);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            try
            {
                await _serviceRepository.CreateService(service);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service service)
        {
            try
            {
                var dbService = await _serviceRepository.GetService(id);
                if (dbService == null)
                {
                    return NotFound();
                }
                else
                {
                    await _serviceRepository.UpdateService(id, service);

                    return Ok("Ok");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var dbService = await _serviceRepository.GetService(id);
                if (dbService == null)
                {
                    return NotFound();
                }
                else
                {
                    await _serviceRepository.DeleteService(id);
                    return Ok("Ok");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
