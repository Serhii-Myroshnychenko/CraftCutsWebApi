using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DapperContext _context;
        public BlogRepository(DapperContext context)
        {
            _context = context;
        }

        public Task CreateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBlog(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> GetBlog(int id)
        {
            var query = "SELECT * FROM Blog Where blog_id = @id";
            using(var connection = _context.CreateConnection())
            {
                var blog = await connection.QuerySingleOrDefaultAsync<Blog>(query, new { id });
                return blog;
            }
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            var query = "SELECT * FROM Blog";
            using (var connection = _context.CreateConnection())
            {
                var blogs = await connection.QueryAsync<Blog>(query);
                return blogs.ToList();
            }
        }

        public Task UpdateBlog(int id, Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
