namespace RestaurantManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;    


        public ICollection<Dish> dishes { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
