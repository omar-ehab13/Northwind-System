namespace Northwind.Core.Helpers.Pagination
{
    public class PaginatedResultMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PaginatedResultMetaData(int currentPage, int pageSize, int totalCount)
        {
            this.CurrentPage = currentPage > 1 ? currentPage : 1;
            this.PageSize = pageSize > 1 ? pageSize : 10;
            this.TotalCount = totalCount;
            this.TotalPages = (int)Math.Ceiling(totalCount / (double)this.PageSize);
        }
    }
}
