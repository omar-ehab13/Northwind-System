using MediatR;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts.MetaData;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetProductById;
using Northwind.Application.FilterHandlers;
using Northwind.Application.Mappings.ProductsMapping.Queries;
using Northwind.Core.Entities;
using Northwind.Core.Extensions;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : ResponseHandler, IRequestHandler<GetAllProductsQuery, GenericResponse<List<GetAllProductsDto>>>
    {
        private readonly IRepositoryManager repositoryManager;

        public GetAllProductsHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<List<GetAllProductsDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await repositoryManager.Products
                    .FindAllWithIncludes(new string[] { nameof(Product.Category), nameof(Product.Supplier) }, false);

            products = await new ProductFilterHandler(repositoryManager)
                .FilterAsync(products, request);

            var productMetaData = await ProductMetaDataFactory.CreateProductsMetaDataAsync(products, request);

            products = await products.PaginateAsync(request.PageNumber, request.PageSize);

            List<GetAllProductsDto> result = products.Select(p => p.MapToGetAllProductsDto()).ToList();

            return Succeeded(result, productMetaData);
        }
    }
}
