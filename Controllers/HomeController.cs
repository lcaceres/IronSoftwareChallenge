using IronSoftwareChallenge.Models;
using IronSoftwareChallenge.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IronSoftwareChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessKey(string text)
        {
            var result = TextDecoder.Decode(text);
            return Json(new { result });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
