using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers.MetaData
{
    public class SupplierMetaDataFactory : PaginationMetaDataFactory
    {
        public static async Task<SupplierMetaData> CreateSupplierMetaData(IQueryable<Supplier> suppliers, GetAllSuppliersQuery request)
        {
            var count = await suppliers.CountAsync();

            var paginationMetaData = CreatePaginationMetaData(request.PageNumber, request.PageSize, count);

            return new(paginationMetaData.CurrentPage, paginationMetaData.PageSize, paginationMetaData.TotalCount);
        }
    }
}
