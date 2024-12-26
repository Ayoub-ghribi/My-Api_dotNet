using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_api.Models;

namespace My_api.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ImgAnimation> imgAnimations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp=Guid.NewGuid().ToString()
                },
                new IdentityRole()
                {
                     Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

