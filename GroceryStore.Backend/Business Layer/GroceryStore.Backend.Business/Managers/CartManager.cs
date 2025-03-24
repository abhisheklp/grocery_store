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
    public class CartManager : ICartManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddProductToCart(CartDTO cartItem)
        {
            CartValidator cartValidator = new CartValidator();
            ValidationResult result = cartValidator.Validate(cartItem);

            if(result.IsValid)
            {
                var entity = _mapper.Map<CartEntity>(cartItem);
                var response = await _unitOfWork.CartRepository.AddProductToCart(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<CartDTO>> GetCartItemsByUser(string userName)
        {
            var response = await _unitOfWork.CartRepository.GetCartItemsByUser(userName);
            return _mapper.Map<IEnumerable<CartDTO>>(response);
        }

        public async Task<bool> UpdateCartItemById(int id, int newQuantity)
        {
            var request = await _unitOfWork.CartRepository.UpdateCartItemById(id, newQuantity);
            return request;
        }

        public async Task<bool> DeleteCartItemById(int id)
        {
            var request = await _unitOfWork.CartRepository.DeleteCartItemById(id);
            return request;
        }

        public async Task<bool> DeleteCartItemsAfterOrder(string userName)
        {
            var request = await _unitOfWork.CartRepository.DeleteCartItemsAfterOrder(userName);
            return request;
        }

    }
}
