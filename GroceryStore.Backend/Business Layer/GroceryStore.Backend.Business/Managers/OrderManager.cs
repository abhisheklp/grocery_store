using AutoMapper;
using FluentValidation.Results;
using GroceryStore.Backend.Business.DTO;
using GroceryStore.Backend.Business.Managers.Interface;
using GroceryStore.Backend.Business.UoW;
using GroceryStore.Backend.Business.Validation;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Business.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddOrders(OrderDTO order)
        {
            OrderValidator orderValidator = new OrderValidator();
            ValidationResult result = orderValidator.Validate(order);
            if(result.IsValid)
            {
                var entity = _mapper.Map<OrderEntity>(order);
                var response = await _unitOfWork.OrderRepository.AddOrders(entity);
                return response;
            }
            return -1;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders(string userEmail)
        {
            var response = await _unitOfWork.OrderRepository.GetOrders(userEmail);
            return _mapper.Map<IEnumerable<OrderDTO>>(response);
        }
    }
}
