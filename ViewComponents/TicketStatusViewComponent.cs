using Microsoft.AspNetCore.Mvc;

namespace OlympicGamesSite.ViewComponents
{
    public class TicketStatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string currentStatus)
        {
            var statuses = new List<string> { "To Do", "In Progress", "QA", "Done" };
            ViewBag.CurrentStatus = currentStatus;
            return View(statuses);
        }
    }
}

