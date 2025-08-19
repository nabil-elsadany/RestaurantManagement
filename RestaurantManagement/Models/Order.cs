namespace RestaurantManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public StatusEnum Status { get; set; } 
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } 

    }
}
