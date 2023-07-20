namespace E_Commerce.CatalogService.Domain.Entities.Common
{
    public interface IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
