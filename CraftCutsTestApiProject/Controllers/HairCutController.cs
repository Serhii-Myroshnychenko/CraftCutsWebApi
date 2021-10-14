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
    public class HairCutController : ControllerBase
    {
        private readonly IHairCutRepository _hairCutRepository;
        public HairCutController(IHairCutRepository hairCutRepository)
        {
            _hairCutRepository = hairCutRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetHairCuts()
        {
            try
            {
                var hairCuts = await _hairCutRepository.GetHairCuts();
                return Ok(hairCuts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHairCut(int id)
        {
            try
            {
                var hairCut = await _hairCutRepository.GetHairCut(id);
                return Ok(hairCut);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
