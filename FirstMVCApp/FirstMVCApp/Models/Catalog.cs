using FirstMVCApp.Models.MailServ;
using FirstMVCApp.Services;
using System.Collections.Concurrent;

namespace FirstMVCApp.Models
{
    public class Catalog : ICatalog
    {
        private long index;
        public Catalog()
        {
            index = 0;
            ProductsList = new ConcurrentDictionary<long, Product>();
        }

        public ConcurrentDictionary<long, Product> ProductsList { get; set; }

        public long GetNewIndex()
            => Interlocked.Increment(ref index);

        public void AddProduct(Product product, long index)
        {
            ProductsList.TryAdd(index, product);
        }

        public void RemoveProduct(int id)
        {
            var productToRemove = ProductsList.Where(x => x.Value.Id == id);
            foreach (var item in productToRemove)
            {
                ProductsList.TryRemove(item.Key, out _);
            }
        }

        public Product? Get(long index)
        {
            ProductsList.TryGetValue(index, out Product? product);
            return product;
        }

        public IReadOnlyList<Product> GetList()
            => ProductsList.Values.ToList().AsReadOnly();
    }
}
