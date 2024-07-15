using Microsoft.AspNetCore.Mvc;

namespace Curate.AI.Controllers
{
    public class SiteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SiteController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (file != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); //Random name to image file
                    string productPath = Path.Combine(wwwRootPath, @"userImg");

                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ViewData["img"] = @"wwwroot\UserImg\"+filename;
                    return View("Result");
                }
            }
            return View();
        }
    }
}
