using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGamesSite.Data;

namespace OlympicGamesSite.Controllers
{
    public class SportsController : Controller
    {
        private readonly OlympicsDbContext _context;

        public SportsController(OlympicsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string gameFilter = "ALL", string categoryFilter = "ALL")
        {
            var query = _context.Sports.AsQueryable();

            if (gameFilter != "ALL")
                query = query.Where(s => s.Game == gameFilter);

            if (categoryFilter != "ALL")
                query = query.Where(s => s.Category == categoryFilter);

            var sports = await query.OrderBy(s => s.Country).ToListAsync();

            ViewBag.Games = await _context.Sports.Select(s => s.Game).Distinct().ToListAsync();
            ViewBag.Categories = await _context.Sports.Select(s => s.Category).Distinct().ToListAsync();
            ViewBag.GameFilter = gameFilter;
            ViewBag.CategoryFilter = categoryFilter;

            return View(sports);
        }
    }
}
