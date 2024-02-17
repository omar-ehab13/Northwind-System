using MediatR;
using Northwind.Application.Mappings.CategoriesMapping.Commands;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.AddCategory
{
    public class AddCategoryHandler : ResponseHandler, IRequestHandler<AddCategoryCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;

        public AddCategoryHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<object>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = request.MapAddCategoryCommandToCategoy();

            if (!await repositoryManager.Categories.CreateAsync(newCategory))
                return BadRequest<object>("Error During Adding New Categoy");

            await repositoryManager.SaveChangesAsync();

            return Created<object>(newCategory);
        }
    }
}
