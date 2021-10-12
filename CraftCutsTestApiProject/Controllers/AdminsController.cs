using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CraftCutsTestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        public AdminsController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            try
            {
                var admins = await _adminRepository.GetAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(Admin admin)
        {
            try
            {
                await _adminRepository.CreateAdmin(admin);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        

    }
}
