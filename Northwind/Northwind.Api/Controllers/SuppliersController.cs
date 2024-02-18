using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Base;
using Northwind.Application.Features.ProductsFeature.Suppliers.Commands.AddSupplier;
using Northwind.Application.Features.ProductsFeature.Suppliers.Commands.DeleteSupplier;
using Northwind.Application.Features.ProductsFeature.Suppliers.Commands.UpdateSupplier;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetSupplierById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : AppBaseController
    {
        public SuppliersController(IMediator mediator) : base(mediator)
        {

        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSuppliersQuery query)
        {
            var resposne = await _mediator.Send(query);

            return NewResult(resposne);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetSupplierByIdQuery(id));

            return NewResult(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSupplierCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSupplierCommand command)
        {
            command.SupplierId = id;

            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteSupplierCommand(id));

            return NewResult(response);
        }
    }
}
