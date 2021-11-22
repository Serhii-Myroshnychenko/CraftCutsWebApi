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
    public class PromocodeController : ControllerBase
    {
        private readonly IPromocodeRepository _promocodeRepository;
        public PromocodeController(IPromocodeRepository promocodeRepository)
        {
            _promocodeRepository = promocodeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPromocodes()
        {
            try
            {

                var promocodes = await _promocodeRepository.GetPromocodes();
                return Ok(promocodes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromocode(int id)
        {
            try
            {
                var promocode = await _promocodeRepository.GetPromocode(id);
                if(promocode != null)
                {
                    return Ok(promocode);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocode(int id)
        {
            try
            {
                await _promocodeRepository.DeletePromocode(id);
                return Ok("Ok");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
