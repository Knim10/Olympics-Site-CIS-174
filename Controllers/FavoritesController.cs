using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Data;
using OlympicGamesSite.Helpers;
using Microsoft.EntityFrameworkCore;


namespace OlympicGamesSite.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly OlympicsDbContext _context;

        public FavoritesController(OlympicsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var favoriteIds = FavoriteManager.GetFavorites(HttpContext.Session);
            var favorites = await _context.Sports.Where(s => favoriteIds.Contains(s.Id)).ToListAsync();
            return View(favorites);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            FavoriteManager.ClearFavorites(HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }
    }

}
