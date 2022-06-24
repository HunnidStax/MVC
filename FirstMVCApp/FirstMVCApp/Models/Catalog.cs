namespace FirstMVCApp.Models
{
    public class Catalog : ICatalog
    {
        private object syncObj = new();
        public Catalog()
        {
            ProductsList = new List<Product>();
        }

        public List<Product> ProductsList { get; set; }

        public void AddProduct(Product product)
        {
            lock (syncObj)
            {
                ProductsList.Add(product);
            }
        }

        public IReadOnlyList<Product> Get()
        {
            lock (syncObj)
            {
                return ProductsList.AsReadOnly();
            }
        }
    }
}
