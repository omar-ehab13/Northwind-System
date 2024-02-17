using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories.MetaData
{
    public class CategoryMetaData : PaginationMetaData
    {
        public CategoryMetaData(PaginationMetaData paginationMetaData) :
            base(paginationMetaData.CurrentPage, paginationMetaData.PageSize, paginationMetaData.TotalCount)
        {

        }
    }
}
