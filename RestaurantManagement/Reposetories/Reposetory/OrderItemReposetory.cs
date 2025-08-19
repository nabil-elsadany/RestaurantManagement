using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class OrderItemReposetory : Repository<OrderItem>, IOrderItemReposetory
    {
        private readonly ApplicationDbcontext _context;
        public OrderItemReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
           _context = applicationDb;
        }
        
     
    }
}
