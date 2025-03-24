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
    [Route("myOrder")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper, IOrderManager orderManager)
        {
            _mapper = mapper;
            _orderManager = orderManager;
        }

        /// <summary>
        /// Retrieves orders for the specified user.
        /// </summary>
        /// <param name="userEmail">The email of the user.</param>
        /// <returns>Returns the list of orders for the user.</returns>
        [HttpGet("{userEmail}")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders(string userEmail)
        {
            var response = await _orderManager.GetOrders(userEmail);
            return Ok(_mapper.Map<IEnumerable<OrderModel>>(response));
        }

        /// <summary>
        /// Adds a new order.
        /// </summary>
        /// <param name="order">The order to add.</param>
        /// <returns>Returns the ID of the added order.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> AddOrder(OrderModel order)
        {
            order.OrderDate = DateTime.Now;
            var dto = _mapper.Map<OrderDTO>(order);
            return Ok(await _orderManager.AddOrders(dto));
        }
    }
}
