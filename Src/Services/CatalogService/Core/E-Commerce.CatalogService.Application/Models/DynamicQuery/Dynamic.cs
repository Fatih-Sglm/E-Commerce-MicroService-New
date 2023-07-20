namespace E_Commerce.CatalogService.Application.Models.DynamicQuery;

public class Dynamic
{
    public Sort? Sort { get; set; }
    public Filter? Filter { get; set; }

    public Dynamic()
    {
    }

    public Dynamic(Sort? sort, Filter? filter)
    {
        Sort = sort;
        Filter = filter;
    }
}