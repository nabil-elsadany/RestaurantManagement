namespace RestaurantManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
      
    }
}
