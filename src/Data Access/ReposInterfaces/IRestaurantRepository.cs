using Data_Access.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantMenu>> GetRestaurantMenuAsync(int RestId);
        Task<List<Restaurant>> GetRestaurantsAsync();
    }
}