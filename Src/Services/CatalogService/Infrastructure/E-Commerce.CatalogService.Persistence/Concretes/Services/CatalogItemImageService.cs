using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Abstractions.Storage;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Rules;
using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services
{
    public class CatalogItemImageService : ICatalogItemImageService
    {
        private readonly IStorage _storage;

        public CatalogItemImageService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<List<CatalogItemImage>> CreateCatalogItemImage(CatalogItem catalogItem, string folderName, IFormFileCollection? files)
        {
            await catalogItem.CannotNull("");
            List<CatalogItemImage> catalogItemImages = new();
            if (files is not null)
            {
                var value = await _storage.UploadAsync(folderName, files);
                foreach (var (fileName, pathOrContainerName) in value)
                {
                    CatalogItemImage catalogItemImage = new()
                    {
                        CatalogItem = catalogItem,
                        FileName = fileName,
                        Path = pathOrContainerName
                    };
                    catalogItemImages.Add(catalogItemImage);
                }
            }
            return catalogItemImages;
        }
        public Task<List<string>> GetCatalogItemImage(CatalogItem catalogItem)
        {
            return GetCatalogItemImageWithList(catalogItem.CatalogItemImages!.ToArray());
        }

        public Task<List<string>> GetCatalogItemImageWithList(CatalogItemImage[] catalogItemImages)
        {
            List<string> ImagePaths = new();

            foreach (var item in catalogItemImages)
            {
                ImagePaths.Add(_storage.GetFile(item.Path)!);
            }
            return Task.FromResult(ImagePaths);
        }
    }
}
