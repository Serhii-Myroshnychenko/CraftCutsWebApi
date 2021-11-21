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
    public class ReviewRepository : IReviewRepository
    {
        private readonly DapperContext _dapperContext;
        public ReviewRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;

        }

        public async Task CreateReview(ReviewConstructor reviewConstructor)
        {
            var query = "INSERT INTO Review (customer_id,feedback,stars) VALUES (@customer_id,@feedback,@stars)";
            var parameters = new DynamicParameters();
            parameters.Add("customer_id", reviewConstructor.Customer_id, DbType.Int64);
            parameters.Add("feedback", reviewConstructor.Feedback, DbType.String);
            parameters.Add("stars", reviewConstructor.Stars, DbType.Int64);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteReview(int id)
        {
            var query = "DELETE FROM Review WHERE review_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Review> GetReview(int id)
        {
            var query = "SELECT * FROM Review where review_id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var review = await connection.QuerySingleOrDefaultAsync<Review>(query, new { id});
                return review;
            }
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            var query = "SELECT * FROM Review";
            using (var connection = _dapperContext.CreateConnection())
            {
                var reviews = await connection.QueryAsync<Review>(query);
                return reviews.ToList();
            }
        }
    }
}
