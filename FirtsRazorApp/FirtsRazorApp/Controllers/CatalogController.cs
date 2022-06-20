using Microsoft.AspNetCore.Mvc;
using FirtsRazorApp.Models;

namespace FirtsRazorApp.Controllers
{
    public class CatalogController : Controller
    {
        private static CatalogModel _catalog = new();

        [HttpGet]
        public IActionResult Categories()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult Categories(Category model)
        {
            _catalog.Categories.Add(model);
            return View(_catalog);
        }
    }
}
