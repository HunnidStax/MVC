using FirstMVCApp.Models;
using FirstMVCApp.Models.MailServ;

namespace FirstMVCApp.Services
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalog _catalog;
        private readonly ISendMailService _mailService;

        public CatalogManager(ICatalog catalog,
            ISendMailService mailService)
        {
            _catalog = catalog;
            _mailService = mailService;
        }
        public void Create(Product product)
        {
            var currentIndex = _catalog.GetNewIndex();
            _catalog.AddProduct(product, currentIndex);
            _mailService.Send(GetMailFields());
        }

        public Product? Get(long index)
            => _catalog.Get(index);

        public IReadOnlyList<Product> GetList()
            => _catalog.GetList();

        public void Delete(int id)
            => _catalog.RemoveProduct(id);

        private MailFields GetMailFields()
        {
            return new MailFields(
                from: "asp2022gb@rodion-m.ru",
                password: "3drtLSa1",
                to: "bigsosaHunnidStax@yandex.ru",
                subject: "Notification",
                body: "New goods added",
                host: "smtp.beget.com",
                port: 25);
        }
    }
}
