using FirstMVCApp.Models;

namespace FirstMVCApp.Services
{
    public interface ICatalogManager
    {
        void Create(Product product);
        Task CreateAsync(Product product);
        void Delete(int id);
        Product? Get(long index);
        IReadOnlyList<Product> GetList();
    }
}
