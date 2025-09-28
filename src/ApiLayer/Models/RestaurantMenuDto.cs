namespace ApiLayer.Models
{
    public class RestaurantMenuDto
    {
        public int Id { get; set; }
        public int RestID { get; set; }
        public int ItemCatID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
