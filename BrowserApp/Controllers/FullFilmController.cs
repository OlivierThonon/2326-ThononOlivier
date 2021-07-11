using BrowserApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrowserApp.Controllers
{
    public class FullFilmController : Controller
    {
        public FullFilmController() { }

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
