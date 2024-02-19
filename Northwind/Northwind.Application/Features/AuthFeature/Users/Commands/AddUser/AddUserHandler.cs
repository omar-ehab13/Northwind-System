using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Application.Mappings.UsersMapping;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.AddUser
{
    public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<NorthwindUser> _userManager;
        private readonly IMapper _mapper;

        public AddUserHandler(IRepositoryManager repositoryManager, UserManager<NorthwindUser> userManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<GenericResponse<object>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _repositoryManager.BeginTransactionAsync();

            try
            {
                var newUser = request.MapAddUserCommand();
                var result = await _userManager.CreateAsync(newUser, request.Password);

                if (!result.Succeeded)
                    return BadRequest<object>(String.Join(",", result.Errors.Select(e => e.Description)));

                //await _userManager.AddToRoleAsync(newUser, "User");

                await transaction.CommitAsync();

                return Created<object>(null!);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest<object>(string.Join("\n", ex.Message, ex.StackTrace));
            }
        }
    }
}
