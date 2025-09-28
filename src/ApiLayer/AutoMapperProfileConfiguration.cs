using ApiLayer.Models;
using AutoMapper;
using Data_Access;
using Data_Access.Model;

namespace ApiLayer
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantMenu, RestaurantMenuDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateOrderDto, CreateOrder>();
            CreateMap<CreateOrderDetailDto,CreateOrderDetail>(); 
        }
    }
}
