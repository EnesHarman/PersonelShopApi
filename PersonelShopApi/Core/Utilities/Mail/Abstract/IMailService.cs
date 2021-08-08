using Core.Utilities.Mail.Concrete;
using System.Threading.Tasks;

namespace Core.Utilities.Mail.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailContent mail);
    }
}
