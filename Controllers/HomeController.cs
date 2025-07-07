using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Models;

namespace OlympicGamesSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(HomeIndexViewModel vm)
        {
            return View(vm);
        }
    }
}
