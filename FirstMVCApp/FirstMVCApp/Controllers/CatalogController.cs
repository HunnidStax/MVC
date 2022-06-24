using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
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
        public IActionResult ProductOnCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductOnCreate([FromForm] Product product)
        {
            _catalog.ProductsList.Add(product);
            return View();
        }
    }
}
