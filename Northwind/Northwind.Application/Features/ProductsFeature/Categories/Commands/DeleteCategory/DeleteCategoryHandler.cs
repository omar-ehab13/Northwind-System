using MediatR;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : ResponseHandler, IRequestHandler<DeleteCategoryCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;

        public DeleteCategoryHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repositoryManager.Categories
                .GetByIdAsync(request.Id);

            if (category is null) return NotFound<object>("The Category Not Found");

            if (!await repositoryManager.Categories.RemoveAsync(category))
                return BadRequest<object>("Error during deleting category from DB");

            await repositoryManager.SaveChangesAsync();

            return Deleted<object>();
        }
    }
}
