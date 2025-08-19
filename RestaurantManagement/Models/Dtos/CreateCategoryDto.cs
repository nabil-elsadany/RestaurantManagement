namespace RestaurantManagement.Models.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> dishids { get; set; }

        public int UserId { get; set; }

       


        }
}
