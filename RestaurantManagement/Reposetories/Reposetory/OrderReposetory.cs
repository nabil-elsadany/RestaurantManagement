using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class OrderReposetory : Repository<Order> , IOrderReposetory
    {
        private readonly ApplicationDbcontext _context;
        public OrderReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
            _context = applicationDb;
        }
       
    }
    
}
