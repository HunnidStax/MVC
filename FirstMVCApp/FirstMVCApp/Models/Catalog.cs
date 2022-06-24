namespace FirstMVCApp.Models
{
    public class Catalog
    {
        public Catalog()
        {
            ProductsList = new List<Product>();
        }

        public List<Product> ProductsList { get; set; }
    }
}
