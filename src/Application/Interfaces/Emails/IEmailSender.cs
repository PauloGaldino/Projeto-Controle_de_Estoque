using System.Threading.Tasks;

namespace Application.Interfaces.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
