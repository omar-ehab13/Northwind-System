using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<GenericResponse<object>>
    {
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
