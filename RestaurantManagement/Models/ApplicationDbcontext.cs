using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement.Models
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Inventory> inventories  { get; set; }
        public DbSet<User> Users { get; set; }


        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ده عشان اجيب كل الكونفيجريشن مرة واحده 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbcontext).Assembly);
            // ده لو هنحطه واحد ب واحد 
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
