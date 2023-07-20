namespace E_Commerce.CatalogService.Application.Models.DynamicQuery;

public class Sort
{
    public string Field { get; set; }
    public string Dir { get; set; }

    public Sort(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }
}