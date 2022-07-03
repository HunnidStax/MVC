using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using FirstMVCApp.Services;

namespace FirstMVCApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Catalog"] = _catalogManager.GetList();
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
            _catalogManager.Create(product);
            return View();
        }
        [HttpGet]
        public IActionResult ProductDeletion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductDeletion([FromForm] Product product)
        {
            _catalogManager.Delete(product.Id);
            return View();
        }
    }
}
