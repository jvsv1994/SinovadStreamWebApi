using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Infrastructure;

namespace SinovadDemo.Infrastructure.EmailSender
{
    public class EmailSenderService : IEmailSenderService
    {

        private readonly SmtpSettings _smtpSettings;

        public EmailSenderService(IOptions<MyConfig> config)
        {
            _smtpSettings = config.Value.SmtpSettings;
        }

        public async Task SendEmailAsync(MailRequest request)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", request.Email));
                message.Subject = request.Subject;
                message.Body = new TextPart("html") { Text = request.Body };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port);
                    await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
