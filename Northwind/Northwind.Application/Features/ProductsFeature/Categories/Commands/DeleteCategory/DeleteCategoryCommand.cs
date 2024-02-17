using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<GenericResponse<object>>
    {
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
