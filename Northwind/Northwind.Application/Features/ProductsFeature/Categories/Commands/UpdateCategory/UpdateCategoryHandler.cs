using MediatR;
using Northwind.Application.Mappings.CategoriesMapping.Commands;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : ResponseHandler, IRequestHandler<UpdateCategoryCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;

        public UpdateCategoryHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repositoryManager.Categories
                .GetByIdAsync(request.CategoryId);

            if (category is null) return NotFound<object>("Category Not Found!");

            category = request.MapUpdateCategoryCommandToCategoy(category);

            await repositoryManager.SaveChangesAsync();

            return Succeeded<object>(category, message: "Updated");
        }
    }
}
