using System.Linq.Dynamic.Core;

namespace Northwind.Core.Extensions
{
    public static class IQueryablePaginationExtension
    {
        public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            return await Task.FromResult(source.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }
    }

    public static class IQueryableSearchExtension
    {
        public static async Task<IQueryable<T>> SearchAsync<T>(this IQueryable<T> query, string? searchTerm, string[] searchFields)
        {
            if (string.IsNullOrEmpty(searchTerm) || searchFields == null || searchFields.Length == 0)
                return await Task.FromResult(query);

            foreach (var field in searchFields)
            {
                query = query.Where($"{field}.Contains(@0)", searchTerm);
            }

            return await Task.FromResult(query);
        }
    }
}
