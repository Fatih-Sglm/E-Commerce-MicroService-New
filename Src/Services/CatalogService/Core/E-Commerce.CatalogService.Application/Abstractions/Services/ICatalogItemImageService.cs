using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Application.Abstractions.Services
{
    public interface ICatalogItemImageService
    {
        Task<List<CatalogItemImage>> CreateCatalogItemImage(CatalogItem catalogItem, string FolderName, IFormFileCollection files);
        //Task<List<string>> GetCatalogItemImage(uint catalogItemId);
        Task<List<string>> GetCatalogItemImage(CatalogItem catalogItem);
        Task<List<string>> GetCatalogItemImageWithList(CatalogItemImage[] catalogItemImages);
    }
}
