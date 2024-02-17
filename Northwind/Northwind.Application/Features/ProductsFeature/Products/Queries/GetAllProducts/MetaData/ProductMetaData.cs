using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts.MetaData
{
    public class ProductMetaData : PaginationMetaData
    {
        public ProductMetaData(PaginationMetaData paginationMetaData, decimal minUnitPrice, decimal maxUnitPrice)
            : base(paginationMetaData.CurrentPage, paginationMetaData.PageSize, paginationMetaData.TotalCount)
        {
            MinUnitPrice = minUnitPrice;
            MaxUnitPrice = maxUnitPrice;
        }

        public decimal MinUnitPrice { get; }
        public decimal MaxUnitPrice { get; }
    }
}
