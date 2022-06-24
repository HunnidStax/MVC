namespace FirstMVCApp.Models
{
    public interface ICatalog
    {
        void AddProduct(Product product);
        IReadOnlyList<Product> Get();
        Product? Get(long index);
        void RemoveProduct(int Id);
    }
}