using Microsoft.AspNetCore.Mvc;
using FirtsRazorApp.Models;

namespace FirtsRazorApp.Controllers
{
    public class ProductController : Controller
    {
        private static ProductModel _product = new();

        [HttpGet]
        public IActionResult Products()
        {
            return View(_product);
        }

        [HttpPost]
        public IActionResult Products(Product model)
        {
            _product.ProductsList.Add(model);
            return View(_product);
        }
    }
}
