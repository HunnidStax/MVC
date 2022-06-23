using System.Collections.Generic;

namespace FirtsRazorApp.Models
{
    public class Catalog
    {
        public Catalog()
        {
            ProductList = new List<Product>();
        }

        public List<Product> ProductList { get; set; }
    }
}
