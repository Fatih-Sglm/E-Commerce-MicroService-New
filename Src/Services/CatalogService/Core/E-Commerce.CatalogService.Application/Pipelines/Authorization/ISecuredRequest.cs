namespace E_Commerce.CatalogService.Application.Pipelines.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}