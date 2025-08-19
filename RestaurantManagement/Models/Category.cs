namespace RestaurantManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }


        public ICollection<Dish> dishes { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
