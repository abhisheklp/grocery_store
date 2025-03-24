using GroceryStore.Backend.DAL.Entities;
using System;

namespace GroceryStore.Backend.DAL.Repository.Interface
{
    public interface IReviewRepository
    {
        Task<int> AddReview(ReviewEntity newReview);
        Task<IEnumerable<ReviewEntity>> GetReviewByProductId(int productId);
    }
}
