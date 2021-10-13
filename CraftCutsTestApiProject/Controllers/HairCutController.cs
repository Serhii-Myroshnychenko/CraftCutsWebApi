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
    public class HairCutController : ControllerBase
    {
        private readonly IHairCutRepository _haircutRepository;
        public HairCutController(IHairCutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetHairCuts()
        {
            try
            {
                var haircuts = await _haircutRepository.GetHairCuts();
                return Ok(haircuts);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
