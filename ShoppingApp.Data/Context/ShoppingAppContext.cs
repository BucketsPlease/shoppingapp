using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Models;

namespace ShoppingApp.Data.Context
{
    public class ShoppingAppContext : IdentityDbContext<AppUser>
    {
        public ShoppingAppContext(DbContextOptions<ShoppingAppContext> options)
        : base(options)
        {

        }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<AppUserProductItem> AppUserProductItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuring the composite primary key for the join table
            builder.Entity<AppUserProductItem>()
                .HasKey(up => new { up.UserId, up.ProductItemId });

            // Configuring the many-to-many relationship
            builder.Entity<AppUserProductItem>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProductItems)
                .HasForeignKey(up => up.UserId);

            builder.Entity<AppUserProductItem>()
                .HasOne(up => up.ProductItem)
                .WithMany(p => p.UserProductItems)
                .HasForeignKey(up => up.ProductItemId);
        }
    }
}
