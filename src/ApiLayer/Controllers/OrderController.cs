using ApiLayer.Models;
using AutoMapper;
using Data_Access;
using Data_Access.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;
        public OrderController(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }
        [HttpPost]
        public async Task<int> DoOrder(CreateOrderDto order)
        {
            return await orderRepository.DoOrderAsync(mapper.Map<CreateOrder>(order));

        }
        [HttpGet("{OrderID:int}")]
        public async Task<List<Order>> OrderTracking(int OrderID)
        {
            return await orderRepository.GetUserOrdersAsync(OrderID);
        }
        [HttpPatch("{OrderNumber:int}/Raitings")]
        public async Task<int> RateOrder(int OrderNumber, decimal Rating)
        {
            return await orderRepository.RateOrderAsync(OrderNumber, Rating);
        }
    }
}
