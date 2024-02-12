namespace Northwind.Core.Helpers.MetaData
{
    public class PaginationMetaDataFactory
    {
        protected static PaginationMetaData CreatePaginationMetaData(int currentPage, int pageSize, int count)
            => new PaginationMetaData(currentPage, pageSize, count);
    }
}
