namespace Northwind.Core.Helpers.Pagination
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
