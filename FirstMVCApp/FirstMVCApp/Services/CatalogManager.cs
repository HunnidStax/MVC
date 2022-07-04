using FirstMVCApp.Models;
using FirstMVCApp.Models.MailServ;

namespace FirstMVCApp.Services
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalog _catalog;
        private readonly ISendMailService _mailService;
        private readonly ILogger _logger;

        public CatalogManager(ICatalog catalog,
            ISendMailService mailService,
            ILogger<CatalogManager> logger)
        {
            _catalog = catalog;
            _mailService = mailService;
            _logger = logger;
        }
        public void Create(Product product)
        {
            var currentIndex = _catalog.GetNewIndex();
            _catalog.AddProduct(product, currentIndex);
            _logger.LogInformation("Was added: {name}", product.Name ?? "");
            _mailService.Send("Notification", "Added new product");
        }

        public Product? Get(long index)
            => _catalog.Get(index);

        public IReadOnlyList<Product> GetList()
            => _catalog.GetList();

        public void Delete(int id)
            => _catalog.RemoveProduct(id);
    }
}
