using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Core.Helpers.ResponseBase;
using System.Net;

namespace Northwind.Api.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public AppBaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected IActionResult NewResult<T>(GenericResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                case HttpStatusCode.NoContent:
                    return new OkObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
