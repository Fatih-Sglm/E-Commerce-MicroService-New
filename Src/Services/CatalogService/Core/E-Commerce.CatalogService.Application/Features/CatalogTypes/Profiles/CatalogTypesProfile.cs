using AutoMapper;
using E_Commerce.CatalogService.Application.Features.CatalogTypes.Models;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Application.Features.CatalogTypes.Profiles
{
    public class CatalogTypesProfile : Profile
    {
        public CatalogTypesProfile()
        {
            CreateMap<CatalogType, GetCatalogTypeDto>();
        }
    }
}
