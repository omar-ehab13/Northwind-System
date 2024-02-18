using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers.MetaData
{
    public class SupplierMetaData : PaginationMetaData
    {
        public SupplierMetaData(int currentPage, int pageSize, int count)
            : base(currentPage, pageSize, count)
        {

        }
    }
}
