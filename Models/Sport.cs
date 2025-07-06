using Microsoft.AspNetCore.Mvc;

namespace OlympicGamesSite.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Game { get; set; }
        public string SportName { get; set; }
        public string Category { get; set; }
    }
}
