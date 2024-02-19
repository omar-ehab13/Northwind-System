using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Base;
using Northwind.Application.Features.AuthFeature.Auth.Commands.Login;
using Northwind.Application.Features.AuthFeature.Users.Commands.AddUser;
using Northwind.Application.Features.AuthFeature.Users.Commands.ChangePassword;
using Northwind.Application.Features.AuthFeature.Users.Commands.DeleteUser;
using Northwind.Application.Features.AuthFeature.Users.Commands.UpdateUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : AppBaseController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {

        }

        // GET: api/<AccountsContraoller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountsContraoller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountsContraoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // PUT api/<AccountsContraoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        [HttpPut("{id}/password")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordCommand command)
        {
            command.Id = id;

            var response = await _mediator.Send(command);

            return NewResult(response);
        }

        // DELETE api/<AccountsContraoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));

            return NewResult(response);
        }
    }
}
