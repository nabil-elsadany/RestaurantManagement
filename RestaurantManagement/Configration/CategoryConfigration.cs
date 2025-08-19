using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Bcpg;
using RestaurantManagement.Models;

namespace RestaurantManagement.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Description)
                .HasMaxLength(500);
            builder.HasMany(c => c.dishes)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Users)
                .WithMany(u => u.Categories)
               .UsingEntity<Dictionary<string, object>>(
                    "CategoryUser",
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                .OnDelete(DeleteBehavior.Cascade));

        }
    }
}
