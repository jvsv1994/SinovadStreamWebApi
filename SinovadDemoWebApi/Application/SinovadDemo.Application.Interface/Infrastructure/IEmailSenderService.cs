using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(MailRequest request);
    }
}
