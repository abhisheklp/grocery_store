using GroceryStore.Backend.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers.Interface
{
    public interface IReviewManager
    {
        Task<int> AddReview(ReviewDTO newReview);

        Task<IEnumerable<ReviewDTO>> GetReviewByProductId(int productId);
    }
}
