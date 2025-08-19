namespace RestaurantManagement.Models.Dtos
{
    public class CategoryOutputDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> DishIds { get; set; }

       
    }
}
