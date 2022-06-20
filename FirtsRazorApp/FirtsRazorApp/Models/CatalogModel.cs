using System.Collections.Generic;

namespace FirtsRazorApp.Models
{
    public class CatalogModel
    {
        public List<Category> Categories { get; set; } = new();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
