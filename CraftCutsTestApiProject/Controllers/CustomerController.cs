using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using CraftCutsTestApiProject.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private IHubContext<InformHub, IHubClient> _informHub;
        public CustomerController(ICustomerRepository customerRepository, IHubContext<InformHub, IHubClient> informHub)
        {
            _customerRepository = customerRepository;
            _informHub = informHub;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
        //Bcrypt
        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomer(id);
                
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                await _customerRepository.CreateCustomer(customer);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                var dbCustomer = await _customerRepository.GetCustomer(id);
                if (dbCustomer == null)
                {
                    return NotFound();
                }
                else
                {
                    await _customerRepository.UpdateCustomer(id, customer);
                    
                    return Ok("Ok");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var dbCustomer = await _customerRepository.GetCustomer(id);
                if(dbCustomer == null)
                {
                    return NotFound();
                }
                else
                {
                    await _customerRepository.DeleteCustomer(id);
                    return Ok("Ok");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpPost("Auth")]

        public async Task<IActionResult> AuthorizationCustomer([FromBody] AuthConstructor authConstructor)

        {
            try
            {
                var cust = await _customerRepository.AuthorizationCustomer(authConstructor);
                if (cust == null)
                {
                    return NotFound("Не олег");
                }
                else
                {
                    return Ok(cust);
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(
                    new
                    {
                        message = ex.Message
                    }
                    );
            }
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromForm]Registration registration)
        {
            try
            {
                var customer = await _customerRepository.IsItAnExistingMail(registration.email);
                if(customer == null)
                {
                    await _customerRepository.Registration(registration.name,registration.password,registration.email,registration.phone,registration.birthday);
                    var cust = await _customerRepository.GetCustomerByParams(registration.name,registration.password,registration.email,registration.phone,registration.birthday);
                    return Ok(cust);
                }
                else
                {
                    return BadRequest("Пользователь с такой почтой уже существует");
                }
                

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(
                    new
                    {
                        message  = ex.Message
                    }
                    );
            }
        }
        
    }
}
