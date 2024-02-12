using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Core.Helpers.Pagination
{
    public class PaginatedResultHandler : ResponseHandler
    {
        public GenericResponse<T> PaginationSucceeded<T>(T entity, PaginatedResultMetaData meta, string? message = null)
            => base.Succeeded(entity, meta, message);
    }
}
