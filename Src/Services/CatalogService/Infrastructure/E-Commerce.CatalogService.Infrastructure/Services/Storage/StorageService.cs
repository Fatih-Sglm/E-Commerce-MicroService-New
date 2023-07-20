using E_Commerce.CatalogService.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName => _storage.GetType().Name;

        public Task DeleteAsync(string pathOrContainerName) => _storage.DeleteAsync(pathOrContainerName);

        public string? GetFile(string pathOrContainerName) => _storage.GetFile(pathOrContainerName);

        public bool HasFile(string pathOrContainerName) => _storage.HasFile(pathOrContainerName);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
            => _storage.UploadAsync(pathOrContainerName, files);
    }
}
