using Data_Access.Model;
using System;
using System.Collections.Generic;
using static Data_Access.EnumeratedProperties.DriverTypeEnum;
using static Data_Access.EnumeratedProperties.OrderPriorityCode;

namespace Data_Access
{
    public class Order
    {
        public int Id { set; get; }
        public DriverType? DriverType { set; get; }
        public int? DriverID { set; get; }
        public string? DriverName { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal DeliveryPrice { set; get; }
        public string Restaurant { set; get; }
        public int RestaurantID { set; get; }   
        public string OrderAddress { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }
        public int? UserOrdersCount { set; get; }
        public Status? PriorityCode { set; get; }
        public DateTime OrderStart { set; get; }
        public DateTime? Place { set; get; }
        public DateTime? Pickup { set; get; }
        public DateTime? Assign { set; get; }
        public DateTime? Arrive { set; get; }
        public DateTime? Depart { set; get; }
        public DateTime? Complete { set; get; } 
        public List<OrderDetail> Detail { set; get; }
    }
}
