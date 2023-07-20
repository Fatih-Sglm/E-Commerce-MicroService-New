namespace E_Commerce.OrderService.Application.Models.Paging
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



        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
