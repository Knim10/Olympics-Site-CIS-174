using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Data;
using OlympicGamesSite.Models;

public class TicketController : Controller
{
    private readonly OlympicsDbContext _context;

    public TicketController(OlympicsDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tickets = _context.Tickets.ToList();
        return View(tickets);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound();
        return View(ticket);
    }

    [HttpPost]
    public IActionResult Edit(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound();
        return View(ticket);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound();

        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
