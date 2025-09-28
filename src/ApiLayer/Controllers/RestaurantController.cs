using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data_Access;
using ApiLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRestaurantRepository restaurantRepository;
        public RestaurantController(IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            this.mapper = mapper;
            this.restaurantRepository = restaurantRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            return (await restaurantRepository.GetRestaurantsAsync()).Select(item => mapper.Map<RestaurantDto>(item));
        }

        [HttpGet("{RestID:int}/Products")]
        public async Task<IEnumerable<RestaurantMenuDto>> GetSelectedRestMenu(int RestID)
        {
            return (await restaurantRepository.GetRestaurantMenuAsync(RestID)).Select(item => mapper.Map<RestaurantMenuDto>(item));
        }
    }
}
