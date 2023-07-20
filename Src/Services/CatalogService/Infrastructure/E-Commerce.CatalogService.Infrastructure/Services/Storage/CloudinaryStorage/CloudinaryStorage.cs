using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using E_Commerce.CatalogService.Application.Abstractions.Storage.Cloudinary;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.CatalogService.Infrastructure.Services.Storage.CloudinaryStorage
{
    public class CloudinaryStorage : ICloudinaryStorage
    {
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;

        public CloudinaryStorage(Cloudinary cloudinary, IConfiguration configuration)
        {
            _cloudinary = cloudinary;
            _configuration = configuration;
        }

        public async Task DeleteAsync(string path)
        {
            DeletionParams deletionParams = new(GetPublicId(path));
            await _cloudinary.DestroyAsync(deletionParams);
        }

        public string? GetFile(string path)
        {
            HasFile(path);
            return $"{_configuration.GetSection("CloudinaryImageUrl").Value}/{path}";
        }

        public bool HasFile(string path)
        {
            var value = _cloudinary.GetResourceAsync(GetPublicId(path)).GetAwaiter().GetResult();
            return value is not null;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            if (path is not null)
                await _cloudinary.CreateFolderAsync(path);

            List<(string fileName, string path)> Images = new();
            foreach (var item in files)
            {
                ImageUploadParams imageUploadParams = new()
                {
                    File = new(item.FileName, item.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = false,
                    Folder = path,
                };
                ImageUploadResult result = await _cloudinary.UploadAsync(imageUploadParams);
                Images.Add((item.FileName, $"v{result.Version}/{result.PublicId}"));
            }
            return Images;
        }

        private static string GetPublicId(string path)
        {
            int index = path.IndexOf('/');
            return path[(index + 1)..];
        }

        //private void CreateFolder()
        //{

        //}
    }
}
