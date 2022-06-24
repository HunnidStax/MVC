using System.Collections.Concurrent;

namespace FirstMVCApp.Models
{
    public class Catalog : ICatalog
    {
        private object syncObj = new();
        private long index;
        public Catalog()
        {
            index = 0;
            ProductsList = new ConcurrentDictionary<long, Product>();
        }

        public ConcurrentDictionary<long, Product> ProductsList { get; set; }

        public void AddProduct(Product product)
        {
            var currentIndex = Interlocked.Increment(ref index);
            ProductsList.AddOrUpdate(product.Id, product, (ind, old) => product);
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

        public IReadOnlyList<Product> Get()
            => ProductsList.Values.ToList().AsReadOnly();
    }
}
