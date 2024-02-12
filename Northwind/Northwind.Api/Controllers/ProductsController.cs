using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Features.Products.Queries.GetAllProducts;
using Northwind.Core.Entities;
using Northwind.Infrastructure.RepositoryManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryManager _repositoryManager;

        public ProductsController(IMediator mediator, IRepositoryManager repositoryManager)
        {
            this._mediator = mediator;
            this._repositoryManager = repositoryManager;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQuery query)
        {
            var resposne = await _mediator.Send(query);

            return resposne.Succeeded ? Ok(resposne) : BadRequest(resposne);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var product = await _repositoryManager.Products
                .FindAsync(p => p.ProductId == id, new string[] { "Category" });

            return new
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryName = product.Category is not null ? product.Category.CategoryName : null
            };
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product model)
        {
            await _repositoryManager.Products.CreateAsync(model);

            await _repositoryManager.SaveChangesAsync();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Product model)
        {
            var product = await _repositoryManager.Products.GetByIdAsync(id);

            await _repositoryManager.Products.UpdateAsync(product, model);

            await _repositoryManager.SaveChangesAsync();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var product = await _repositoryManager.Products.GetByIdAsync<int>(id);

            await _repositoryManager.Products.RemoveAsync(product);

            await _repositoryManager.SaveChangesAsync();
        }
    }
}
