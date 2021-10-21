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
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var blogs = await _blogRepository.GetBlogs();
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetBlog(int id)
        {
            try
            {
                var blog = await _blogRepository.GetBlog(id);
                if (blog == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(blog);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            try
            {
                await _blogRepository.CreateBlog(blog);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            try
            {
                var bl = await _blogRepository.GetBlog(id);
                if (bl == null)
                {
                    return NotFound();
                }
                else
                {
                    await _blogRepository.UpdateBlog(id, blog);
                    return Ok("OK");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var bl = await _blogRepository.GetBlog(id);
                if (bl == null)
                {
                    return NotFound();
                }
                else
                {
                    await _blogRepository.DeleteBlog(id);
                    return Ok("OK");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
