using System;
using Data_Access;
using static Data_Access.EnumeratedProperties.DriverTypeEnum;
using static Data_Access.EnumeratedProperties.OrderPriorityCode;

namespace Dispatch_Screen
{
    public class OrderView
    {
        public int Id { set; get; }
        public DriverType? DriverType { set; get; }
        public int? Driver { set; get; }
        public string? DriverName { set; get; }
        public string TotalPrice { set; get; }
        public string Restaurant { set; get; }
        public string OrderAddress { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }
        public int? UserOrdersCount { set; get; }
        public Status? PriorityCode { set; get; }
        public string OrderStart { set; get; }
        public string? Place { set; get; }
        public string? Pickup { set; get; }
        public string? Assign { set; get; }
        public string? Arrive { set; get; }
        public string? Depart { set; get; }
        public string? Complete { set; get; }

        public OrderView(Order order)
        {
            Id = order.Id;
            DriverType = order.DriverType;
            Driver = order.DriverID;
            DriverName = order.DriverName;
            TotalPrice = order.TotalPrice.ToString("N0");
            Restaurant = order.Restaurant;
            OrderAddress = order.OrderAddress;
            FirstName = order.FirstName;
            LastName = order.LastName;
            PhoneNumber = order.PhoneNumber;
            UserOrdersCount = order.UserOrdersCount;
            PriorityCode = order.PriorityCode;
            OrderStart = order.OrderStart.ToString("HH:mm");
            Place = order.Place.HasValue ? order.Place.Value.ToString("HH:mm") : null;
            Pickup = order.Pickup.HasValue ? order.Pickup.Value.ToString("HH:mm") : null;
            Arrive = order.Arrive.HasValue ? order.Arrive.Value.ToString("HH:mm") : null;
            Depart = order.Depart.HasValue ? order.Depart.Value.ToString("HH:mm") : null;
            Complete = order.Complete.HasValue ? order.Complete.Value.ToString("HH:mm") : null;
        }
    }
}
