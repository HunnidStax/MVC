namespace FirstMVCApp.Models
{
    public interface ICatalog
    {
        void AddProduct(Product product, long index);
        IReadOnlyList<Product> GetList();
        Product? Get(long index);
        void RemoveProduct(int Id);
        long GetNewIndex();
    }
}