using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task CreateBlog(Blog blog)
        {
            var query = "INSERT INTO Blog (time_step,title,blog_content,picture_url) values (@time_step,@title,@blog_content,@picture_url);";
            var parameters = new DynamicParameters();
            parameters.Add("time_step", blog.time_step, DbType.DateTime);
            parameters.Add("title", blog.title, DbType.String);
            parameters.Add("blog_content", blog.blog_content, DbType.String);
            parameters.Add("picture_url", blog.picture_url, DbType.String);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }

        }

        public async Task DeleteBlog(int id)
        {

            var query = "DELETE FROM Blog WHERE blog_id = @id";
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id});
            }
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

        public async Task UpdateBlog(int id, Blog blog)
        {
            var query = "UPDATE Blog SET time_step = @time_step, title = @title, blog_content = @blog_content, picture_url = @picture_url WHERE blog_id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("time_step", blog.time_step, DbType.DateTime);
            parameters.Add("title", blog.title, DbType.String);
            parameters.Add("blog_content", blog.blog_content, DbType.String);
            parameters.Add("picture_url", blog.picture_url, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
