using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.CatalogService.Persistence.EntityConfiguration
{
    public class CatalogItemVariantEntityConfiguration : IEntityTypeConfiguration<CatalogItemVariant>
    {
        public void Configure(EntityTypeBuilder<CatalogItemVariant> builder)
        {
            builder.ToTable("CatalogItemVariant");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);

            builder.Property(x => x.VariantName).IsRequired();
            builder.Property(x => x.VariantDescription).IsRequired(false);
            builder.HasMany(x => x.CatalogItems).WithMany(x => x.CatalogItemVariants).
                UsingEntity(join => join.ToTable("CatalogItemsVariants"));
        }

    }
}
