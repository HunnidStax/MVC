using System.Collections.Generic;

namespace FirtsRazorApp.Models
{
    public class ProductModel
    {
        public List<Product> ProductsList { get; set; } = new();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }
}
