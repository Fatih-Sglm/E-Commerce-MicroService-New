using Bogus;
using E_Commerce.CatalogService.Domain.Entities;
using System.Collections.ObjectModel;

namespace E_Commerce.CatalogService.Persistence.SeedData
{
    public class GenerateEntity
    {
        public static (List<CatalogItem> items, List<CatalogItemImage> imageList) CreateCatalogItem(int count)
        {
            List<uint> brands = new() { 1, 2, 3 };
            List<uint> types = new() { 1, 2, 3 };

            Collection<CatalogItemImage> images = new()
            {
                new() {Id = 20028 , FileName="akbey.jpg", Path="v1671933877/shoes/akbey_qqopy0" , IsHeader = true } ,
                new() {Id = 20027 , FileName="akbey.jpg", Path="v1671933877/shoes/akbey_qqopy0" , IsHeader = true } ,
            };

            uint ids = 10032;
            var Faker = new Faker<CatalogItem>()
                .RuleFor(i => i.Id, x => ids++)
                .RuleFor(i => i.CatalogBrandId, y => y.PickRandom(brands))
                .RuleFor(i => i.CatalogTypeId, y => y.PickRandom(types))
                .RuleFor(i => i.Name, y => y.Commerce.ProductName())
                .RuleFor(i => i.Price, y => decimal.Parse(y.Commerce.Price()))
                .RuleFor(i => i.Description, y => y.Lorem.Paragraph());

            var items = Faker.Generate(count);

            uint Id = 20028;
            var image = new Faker<CatalogItemImage>()
                .RuleFor(i => i.Id, x => Id++)
                .RuleFor(i => i.FileName, y => "akbey.jpg")
                .RuleFor(i => i.Path, y => "v1671933877/shoes/akbey_qqopy0")
                .RuleFor(i => i.IsHeader, y => true)
                .RuleFor(i => i.CatalogItemId, y => y.PickRandom(items).Id);

            var imageList = image.Generate(count);

            return (items, imageList);
        }
    }
}
