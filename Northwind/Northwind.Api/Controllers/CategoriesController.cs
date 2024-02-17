using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Base;
using Northwind.Application.Features.ProductsFeature.Categories.Commands.AddCategory;
using Northwind.Application.Features.ProductsFeature.Categories.Commands.DeleteCategory;
using Northwind.Application.Features.ProductsFeature.Categories.Commands.UpdateCategory;
using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories;
using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetCategoryById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : AppBaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {

        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesQuery query)
        {
            var resposne = await _mediator.Send(query);

            return NewResult(resposne);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery(id));

            return NewResult(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryCommand command)
        {
            command.CategoryId = id;

            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand(id));

            return NewResult(response);
        }
    }
}
