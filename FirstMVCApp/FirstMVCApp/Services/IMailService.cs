using FirstMVCApp.Models.MailServ;

namespace FirstMVCApp.Services
{

    public interface ISendMailService
    {
        void Send(string subject, string body);
    }
}
