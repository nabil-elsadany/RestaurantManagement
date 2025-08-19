namespace RestaurantManagement.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
