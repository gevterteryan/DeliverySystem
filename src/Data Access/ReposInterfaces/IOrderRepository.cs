using Data_Access.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access
{
    public interface IOrderRepository
    {
        Task<int> DoOrderAsync(CreateOrder order);
        Task<List<Order>> GetOrdersAsync(bool IsAllOrders);
        Task<List<Order>> GetUserOrdersAsync(int UserID);
        Task<int> RateOrderAsync(int OrderID, decimal OrderRating);
    }
}