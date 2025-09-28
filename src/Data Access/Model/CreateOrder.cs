using System.Collections.Generic;

namespace Data_Access.Model
{
    public class CreateOrder
    {
        public int UserID { set; get; }
        public int RestaurantID { set; get; }
        public decimal DeliveryPrice { set; get; }
        public string PhoneNumber { set; get; }
        public string OrderAddress { set; get; }
        public decimal TotalPrice { set; get; }
        public List<CreateOrderDetail> Detail { set; get; }
    }
}
