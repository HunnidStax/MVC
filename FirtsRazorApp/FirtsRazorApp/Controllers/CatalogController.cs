using Microsoft.AspNetCore.Mvc;
using FirtsRazorApp.Models;

namespace FirtsRazorApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly Catalog _catalog;
        public CatalogController(Catalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Catalog"] = _catalog;
            return View();
        }

        [HttpGet]
        public IActionResult ProductOnCreat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductOnCreat([FromForm] Product product)
        {
            _catalog.ProductList.Add(product);
            return View();
        }
    }
}
