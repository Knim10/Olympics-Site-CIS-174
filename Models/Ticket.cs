using Microsoft.AspNetCore.Mvc;

namespace OlympicGamesSite.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SprintNumber { get; set; }
        public int PointValue { get; set; }
        public string Status { get; set; } = "To Do";
    }

}
