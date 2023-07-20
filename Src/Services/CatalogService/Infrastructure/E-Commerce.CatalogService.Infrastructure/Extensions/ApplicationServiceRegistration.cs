using E_Commerce.CatalogService.Application.Abstractions.Storage;
using E_Commerce.CatalogService.Infrastructure.Enums;
using E_Commerce.CatalogService.Infrastructure.Services.Storage.CloudinaryStorage;
using E_Commerce.CatalogService.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.CatalogService.Infrastructure.Extensions
{
    public static class ApplicationServiceRegistration
    {

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;

                case StorageType.Cloudinary:
                    serviceCollection.AddScoped<IStorage, CloudinaryStorage>();
                    break;
                //case StorageType.Azure:
                //    serviceCollection.AddScoped<IStorage, AzureStorage>();
                //    break;
                //case StorageType.AWS:

                //    break;

                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
