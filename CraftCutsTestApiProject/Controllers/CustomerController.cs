﻿using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
<<<<<<< Updated upstream
        [HttpPost("{Auth}")]
        public async Task<IActionResult> AuthorizationCustomer(string email, string password)
=======
        [HttpPost("Auth")]

        public async Task<IActionResult> AuthorizationCustomer([FromBody] AuthConstructor authConstructor)

>>>>>>> Stashed changes
        {
            try
            {
                var cust = await _customerRepository.AuthorizationCustomer(email,password);
                if (cust == null)
                {
                    return NotFound("олег");
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
        public async Task<IActionResult> Registration(string name, string password, string email, string phone, DateTime birthday)
        {
            try
            {
                await _customerRepository.Registration(name,password,email,phone,birthday);
                return Ok("Успешно");
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
