using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Features.Products.Commands.AddProduct;
using Northwind.Application.Features.Products.Commands.DeleteProduct;
using Northwind.Application.Features.Products.Commands.UpdateProduct;
using Northwind.Application.Features.Products.Queries.GetAllProducts;
using Northwind.Application.Features.Products.Queries.GetProductById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
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
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));

            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;

            var response = await _mediator.Send(command);

            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeletProductCommand(id));

            return response.Succeeded ? Ok(response) : NotFound(response);
        }
    }
}
