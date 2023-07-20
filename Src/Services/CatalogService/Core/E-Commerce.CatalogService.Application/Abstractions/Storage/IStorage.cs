using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainerName);
        string? GetFile(string pathOrContainerName);
        bool HasFile(string pathOrContainerName);
    }
}
