namespace Northwind.Application.Services.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string Message, string? reason);
        //Task<string> GenerateConfiramtionEmailUrl(NorthwindUser user);
    }
}