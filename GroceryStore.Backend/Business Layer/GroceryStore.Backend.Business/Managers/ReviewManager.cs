using AutoMapper;
using FluentValidation.Results;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Business.UoW;
using GroceryStore.Backend.Business.Validation;
using GroceryStore.Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers
{
    public class ReviewManager : IReviewManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddReview(ReviewDTO newReview)
        {
            ReviewValidator reviewValidator = new ReviewValidator();
            ValidationResult result = reviewValidator.Validate(newReview);

            if(result.IsValid)
            {
                var entity = _mapper.Map<ReviewEntity>(newReview);
                var response = await _unitOfWork.ReviewRepository.AddReview(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewByProductId(int productId)
        {
            var response = await _unitOfWork.ReviewRepository.GetReviewByProductId(productId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(response);
        }
    }
}
