using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> GetReviews();
        public Task<IEnumerable<ReviewSelector>> GetReviewSelectors();
        public Task<Review> GetReview(int id);

        public Task CreateReview(ReviewConstructor reviewConstructor);
        public Task DeleteReview(int id);

    }
}
