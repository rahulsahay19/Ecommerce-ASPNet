using System.Threading.Tasks;
using Ordering.Application.Models;

namespace Ordering.Application.Contract.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
