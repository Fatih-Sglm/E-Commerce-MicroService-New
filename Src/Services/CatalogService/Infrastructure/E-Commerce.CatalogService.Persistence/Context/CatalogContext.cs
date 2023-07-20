using E_Commerce.CatalogService.Domain.Entities;
using E_Commerce.CatalogService.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_Commerce.CatalogService.Persistence.Context
{
    public class CatalogContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "catalog";
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CatalogItemVariant> CatalogItemVariants { get; set; }

        public DbSet<CatalogItemImage> CatalogItemImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var (items, imageList) = GenerateEntity.CreateCatalogItem(200);

            modelBuilder.Entity<CatalogItem>().HasData(items);
            modelBuilder.Entity<CatalogItemImage>().HasData(imageList);

        }
    }
}
