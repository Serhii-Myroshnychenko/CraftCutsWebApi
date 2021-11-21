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
    public class DemoBeardController : ControllerBase
    {
        private readonly IDemoBeardRepository _demoBeardRepository;
        public DemoBeardController(IDemoBeardRepository demoBeardRepository)
        {
            _demoBeardRepository = demoBeardRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetDemoBeards()
        {
            try
            {
                var beards = await _demoBeardRepository.GetDemoBeards();
                return Ok(beards);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDemoBeard(int id)
        {
            try
            {
                var beard = await _demoBeardRepository.GetDemoBeard(id);
                return Ok(beard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> AddHairCut([FromForm] DemoBeardConstructor demoBeardConstructor)
        {
            try
            {

                await _demoBeardRepository.CreateDemoBeard(demoBeardConstructor.Image_name, demoBeardConstructor.Displayed_name);
                return Ok("Успешно");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
