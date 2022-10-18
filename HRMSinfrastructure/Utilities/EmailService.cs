using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Common;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;


namespace HRMS.Infrastructure.Utilities
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async void OnCreateEmployee(object? source, EmployeeEventArg e)
        {
            SendEmailDTO emailObj = new();
            emailObj.To = e.Employee.Email;
            emailObj.Subject = "Account verification Link From CypherCrescent HR";
            emailObj.Body = e.Employee.VerificationToken;
            SendEmail(emailObj);
        }
        public async void OnResetPassword(object? source, EmployeeEventArg e)
        {
            SendEmailDTO emailObj = new SendEmailDTO();
            emailObj.To = e.Employee.Email;
            emailObj.Subject = "Password Reset Link From CypherCrescent HR";
            emailObj.Body = e.Employee.ResetToken;
            SendEmail(emailObj);
        }

        private async void SendEmail(SendEmailDTO request)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:Sender").Value));
            //email.To.Add(MailboxAddress.Parse(request.To));
            //email.Subject = request.Subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            //using var smtp = new SmtpClient();
            //smtp.Connect(_config.GetSection("Email:Host").Value, 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_config.GetSection("Email:Sender").Value, _config.GetSection("Email:Password").Value);
            //try
            //{
            //    await smtp.SendAsync(email);
            //}
            //finally
            //{
            //    await smtp.DisconnectAsync(true); 
            //}
        }
    }
}
