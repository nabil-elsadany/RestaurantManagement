using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class DishReposetory : Repository<Dish>, IDishReposetory
    {
        private readonly ApplicationDbcontext _context;
        public DishReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
            _context = applicationDb;
        }
        // Implement methods specific to DishReposetory here
    
    }
}
