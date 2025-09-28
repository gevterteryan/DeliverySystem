using System.ComponentModel.DataAnnotations;

namespace ApiLayer.Models
{
    public class CreateOrderDetailDto
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public byte ItemCount { get; set; }
    }
}
