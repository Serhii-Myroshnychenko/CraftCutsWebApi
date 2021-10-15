using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IBlogRepository
    {
        public Task<IEnumerable<Blog>> GetBlogs();
        public Task<Blog> GetBlog(int id);
        public Task CreateBlog(Blog blog);
        public Task UpdateBlog(int id, Blog blog);
        public Task DeleteBlog(int id);
    }
}
