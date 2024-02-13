using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.Products.Queries._Helpers.MetaData
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
