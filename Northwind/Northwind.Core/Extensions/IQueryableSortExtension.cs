using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Northwind.Core.Extensions
{
    public static class IQueryableSortExtension
    {
        public static async Task<IQueryable<T>>
            SortAsync<T>(this IQueryable<T> source, string? orderByQueryString, string defaultOrderBy, Type type)
        {
            if (string.IsNullOrEmpty(orderByQueryString))
                return await Task.FromResult(source.OrderBy(defaultOrderBy));

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param)) continue;

                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(param.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null) continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrEmpty(orderQuery))
                return await Task.FromResult(source.OrderBy(defaultOrderBy));

            return await Task.FromResult(source.OrderBy(orderQuery));
        }
    }
}
