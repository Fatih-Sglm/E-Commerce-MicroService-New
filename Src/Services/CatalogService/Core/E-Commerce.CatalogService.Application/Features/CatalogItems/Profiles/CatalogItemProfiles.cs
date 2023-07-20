using AutoMapper;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Paging;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Profiles
{
    public class CatalogItemProfiles : Profile
    {
        public CatalogItemProfiles()
        {
            CreateMap<CreateCatalogItemDto, CatalogItem>();
            CreateMap<IPaginate<CatalogItem>, CatalogItemListModel>();
            CreateMap<CatalogItem, GetListCatalogItemDto>().
            ForMember(x => x.CatalogTypeName, y => y.MapFrom(z => z.CatalogType.Name)).
            ForMember(x => x.CatalogBrandName, y => y.MapFrom(z => z.CatalogBrand.Name));



            CreateMap<CatalogItem, GetCatalogItemDto>().
                ForMember(x => x.CatalogTypeName, y => y.MapFrom(z => z.CatalogType.Name)).
                ForMember(x => x.CatalogBrandName, y => y.MapFrom(z => z.CatalogBrand.Name))
                .ForMember(x => x.Price, y => y.MapFrom(x => x.Price));

        }
    }
}
