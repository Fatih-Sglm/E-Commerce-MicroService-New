using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CatalogService.Persistence.EntityConfiguration
{
    public class CatalogTypeEntityConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("Catalog_Type");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.CatalogItems).WithOne(x => x.CatalogType);


            CatalogType[] catalogTypes = new[] {
                new CatalogType() { Id= 1 , Name = "Shoes" ,CreatedDate = DateTime.Now } , new (){ Id=2 , Name= "T-Shirt" ,CreatedDate = DateTime.Now } , new (){  Id = 3 , Name = "tracksuit" , CreatedDate = DateTime.Now} };

            builder.HasData(catalogTypes);
        }
    }
}
