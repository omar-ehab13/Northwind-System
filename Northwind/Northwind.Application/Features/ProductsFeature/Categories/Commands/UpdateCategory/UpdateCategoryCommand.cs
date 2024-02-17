using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<GenericResponse<object>>
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
