using Microsoft.AspNetCore.Mvc;

namespace Curate.AI.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile formFile)
        {

            return View("Result");
        }
    }
}
