using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GenericResponse<GetCategoryByIdDto>>
    {
        public GetCategoryByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
