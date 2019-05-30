using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Garderie.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
