﻿using E_Commerce.CatalogService.Domain.Entities.Common;

namespace E_Commerce.CatalogService.Domain.Entities
{
    public class CatalogBrand : BaseEntity<uint>
    {
        public required string Name { get; set; }
        public ICollection<CatalogItem>? CatalogItems { get; set; }
    }
}