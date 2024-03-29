﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Base;
using Northwind.Application.Features.ProductsFeature.Products.Commands.AddProduct;
using Northwind.Application.Features.ProductsFeature.Products.Commands.DeleteProduct;
using Northwind.Application.Features.ProductsFeature.Products.Commands.UpdateProduct;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetProductById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : AppBaseController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQuery query)
        {
            var resposne = await _mediator.Send(query);

            return NewResult(resposne);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));

            return NewResult(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;

            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeletProductCommand(id));

            return NewResult(response);
        }
    }
}
