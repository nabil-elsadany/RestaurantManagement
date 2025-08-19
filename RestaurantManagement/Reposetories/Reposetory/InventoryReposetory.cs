using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class InventoryReposetory : Repository<Inventory>, IInventoryReposetory
    {
        private readonly ApplicationDbcontext _context;
        public InventoryReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
            _context = applicationDb;
        }
       
    }
    
}
