using MediatR;
using Northwind.Core.Helpers.Pagination;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : PaginationParameters, IRequest<GenericResponse<List<GetAllCategoriesDto>>>
    {
    }
}
