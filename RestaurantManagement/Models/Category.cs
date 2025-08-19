namespace RestaurantManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }= default!;


        public ICollection<Dish> dishes { get; set; }= default!;
        public ICollection<User> Users { get; set; }= default!;
    }
}
