using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategoriesName
{
    public class GetAllCategoriesNameQuery : IRequest<GenericResponse<List<string>>>
    {
    }
}
