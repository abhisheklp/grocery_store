using GroceryStore.Backend.DAL.Data.DbContext;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.DAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GroceryDbContext _groceryDbContext;

        public ReviewRepository(GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
        }

        public async Task<int> AddReview(ReviewEntity newReview)
        {
            await _groceryDbContext.AddAsync(newReview);
            await _groceryDbContext.SaveChangesAsync();
            return newReview.ReviewId;
        }

        public async Task<IEnumerable<ReviewEntity>> GetReviewByProductId(int productId)
        {
            var reviews = await _groceryDbContext.ReviewTable.Where(p => p.ProductEntityId == productId).ToListAsync();
            return reviews;
        }
    }
}
