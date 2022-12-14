namespace StorageWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StorageWebApp.Models;
    using System.Diagnostics;

    public class FileController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FileController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}