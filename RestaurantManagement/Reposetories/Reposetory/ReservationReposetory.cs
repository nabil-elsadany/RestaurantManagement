using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Reposetories.IReposetory;

namespace RestaurantManagement.Reposetories.Reposetory
{
    public class ReservationReposetory : Repository<Reservation>, IReservationReposetory
    {
        private readonly ApplicationDbcontext _context;

        public ReservationReposetory(ApplicationDbcontext applicationDb) : base(applicationDb)
        {
            _context = applicationDb;
        }

    }
}