using E_Commerce.IdentityService.Domain.Entities;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.IdentityService.Persistence.Context
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(new AppRole()
            {
                Name = "Admin",
                Id = Guid.NewGuid(),
                NormalizedName = "ADMİN",
                CreatedDate = DateTime.Now,

            }, new AppRole()
            {
                Name = "Customer",
                Id = Guid.NewGuid(),
                NormalizedName = "CUSTOMER",
                CreatedDate = DateTime.Now,
            });
            base.OnModelCreating(builder);
        }
    }
}
