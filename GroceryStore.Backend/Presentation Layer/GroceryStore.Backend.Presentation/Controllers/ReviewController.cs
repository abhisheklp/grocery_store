using AutoMapper;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Controllers
{
    [ApiController]
    [Route("review")]
    public class ReviewController : Controller
    {
        private readonly IReviewManager _reviewManager;
        private readonly IMapper _mapper;

        public ReviewController(IMapper mapper, IReviewManager reviewManager)
        {
            _mapper = mapper;
            _reviewManager = reviewManager;
        }

        /// <summary>
        /// Adds a new review for a product.
        /// </summary>
        /// <param name="newReview">The new review data.</param>
        /// <returns>Returns the ID of the added review.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddReview(ReviewModel newReview)
        {
            newReview.ReviewDate = DateTime.Now;
            var dto = _mapper.Map<ReviewDTO>(newReview);
            return Ok(await _reviewManager.AddReview(dto));
        }

        /// <summary>
        /// Retrieves all reviews for a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>Returns the list of reviews for the specified product.</returns>
        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> GetReviewByProductId(int productId)
        {
            var response = await _reviewManager.GetReviewByProductId(productId);
            return Ok(_mapper.Map<IEnumerable<ReviewModel>>(response));
        }
    }
}
