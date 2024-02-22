using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Northwind.Application.Mappings.UsersMapping;
using Northwind.Application.Services.Contracts;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.AddUser
{
    public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<NorthwindUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IUrlHelper _urlHelper;
        private readonly IMapper _mapper;

        public AddUserHandler(IRepositoryManager repositoryManager,
            UserManager<NorthwindUser> userManager,
            IEmailService emailService,
            IHttpContextAccessor httpContextAccessor,
            //IUrlHelper urlHelper,
            IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._userManager = userManager;
            this._emailService = emailService;
            this._httpContextAccessor = httpContextAccessor;
            //this._urlHelper = urlHelper;
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

                // Email Confiramtion
                //var confirmationEmailUrl = await _emailService.GenerateConfiramtionEmailUrl(newUser);

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var requestAccessor = _httpContextAccessor.HttpContext!.Request;
                var confirmationEmailUrl = requestAccessor.Scheme + "://" + requestAccessor.Host +
                    @"/api/Accounts/ConfirmEmail?userId=" + newUser.Id + "&code=" + confirmationToken;
                //_urlHelper.Action("ConfirmEmail", "Accounts", new { UserId = newUser.Id, Code = confirmationToken });



                var message = $"To Confirm Email Click Link: <a href='{confirmationEmailUrl}'></a>";

                if (!await _emailService.SendEmail(newUser.Email!, message, "Email Confirmation"))
                    return BadRequest<object>("Erorr during sending the email...");

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
