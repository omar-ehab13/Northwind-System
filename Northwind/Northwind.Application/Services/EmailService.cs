using MailKit.Net.Smtp;
using MimeKit;
using Northwind.Application.Services.Contracts;
using Northwind.Core.Helpers.Auth;

namespace Northwind.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;

        public EmailService(EmailConfig emailConfig)
        {
            this._emailConfig = emailConfig;
        }

        public async Task<bool> SendEmail(string email, string Message, string? subject)
        {
            //sending the Message of passwordResetLink
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailConfig.Host, _emailConfig.Port, true);
                client.Authenticate(_emailConfig.FromEmail, _emailConfig.Password);
                var bodybuilder = new BodyBuilder
                {
                    HtmlBody = $"{Message}",
                    TextBody = "wellcome",
                };
                var message = new MimeMessage
                {
                    Body = bodybuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("Northwind Coperate Team", _emailConfig.FromEmail));
                message.To.Add(new MailboxAddress("testing", email));
                message.Subject = subject ?? "No Submitted";
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            //end of sending email
            return true;
        }

        //public async Task<string> GenerateConfiramtionEmailUrl(NorthwindUser user)
        //{
        //    var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        //    var request = _httpContextAccessor.HttpContext!.Request;
        //    var returnUrl = request.Scheme + "//" + request.Host +
        //        _urlHelper.Action("ConfirmEmail", "Accounts", new { userId = user.Id, code = confirmationToken });

        //    return returnUrl;
        //}
    }
}
