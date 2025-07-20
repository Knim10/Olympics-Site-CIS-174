using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Data;
using OlympicGamesSite.Models;

[Authorize]
public class TicketController : Controller
{
    private readonly ITicketRepository _repo;

    public TicketController(ITicketRepository repo)
    {
        _repo = repo;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var tickets = _repo.GetAll();
        return View(tickets);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Ticket());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(ticket);
            _repo.Save();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticket = _repo.Get(id);
        if (ticket == null) return NotFound();
        return View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _repo.Update(ticket);
            _repo.Save();
            return RedirectToAction("Index");
        }
        return View(ticket);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var ticket = _repo.Get(id);
        if (ticket == null) return NotFound();
        return View(ticket);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var ticket = _repo.Get(id);
        if (ticket == null) return NotFound();

        _repo.Delete(id);
        _repo.Save();
        return RedirectToAction("Index");
    }
}
