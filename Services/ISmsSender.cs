using System.Threading.Tasks;

namespace Garderie.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
