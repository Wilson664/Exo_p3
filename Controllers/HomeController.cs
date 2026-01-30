using System.Diagnostics;
using Exo_P3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo_P3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var message = "Vive ASP.Net Core";
            Console.WriteLine(message);

            return View();
        }

        public IActionResult Privacy()
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
