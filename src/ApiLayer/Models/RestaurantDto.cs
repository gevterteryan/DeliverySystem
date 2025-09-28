namespace ApiLayer.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string CatName { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public string OpeningDate { get; set; }
        public string ClosedDate { get; set; }
        public decimal? Rating { get; set; }
    }
}
