using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class CustomerReposetory : Repository<Customer>, ICustomerReposetory
    {
        private readonly ApplicationDbcontext _context;
        public CustomerReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
            _context = applicationDb;
        }

       
    }
}
