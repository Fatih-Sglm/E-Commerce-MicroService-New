namespace E_Commerce.CatalogService.Application.Paging
{
    public class PageRequest
    {
        public PageRequest()
        {
        }
        public PageRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
