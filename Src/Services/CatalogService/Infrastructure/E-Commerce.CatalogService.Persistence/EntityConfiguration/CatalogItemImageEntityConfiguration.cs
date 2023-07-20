using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CatalogService.Persistence.EntityConfiguration
{
    public class CatalogItemImageEntityConfiguration : IEntityTypeConfiguration<CatalogItemImage>
    {
        public void Configure(EntityTypeBuilder<CatalogItemImage> builder)
        {
            builder.ToTable("Catalog_Item_Image");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.Path).IsRequired();

            CatalogItemImage[] catalogItemImages = new[] {
            new CatalogItemImage() {
            Id = 1,
            CatalogItemId = 1,
            CreatedDate= DateTime.Now,
            Path = "Product//Shoes//Airmax270.png",
            FileName = "Airmax270.png",
            },

            new CatalogItemImage() {
            Id = 2,
            CatalogItemId = 2,
            CreatedDate= DateTime.Now,
            Path = "Product//T-Shirt//GoldenState2022/23_uniform.png",
            FileName = "GoldenState2022/23_uniform.png" } };

            builder.HasData(catalogItemImages);
        }

    }
}
