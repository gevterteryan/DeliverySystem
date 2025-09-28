using System.ComponentModel.DataAnnotations;

namespace ApiLayer.Models
{
    public class CreateOrderDto
    {
        [Required]
        public int UserID { set; get; }
        [Required]
        public int RestaurantID { set; get; }
        [Required]
        public decimal DeliveryPrice { set; get; }
        [Required]
        public string PhoneNumber { set; get; }
        public string OrderAddress { set; get; }
        [Required]
        public decimal TotalPrice { set; get; }
        [Required]
        public List<CreateOrderDetailDto> Detail { set; get; }
    }
}
