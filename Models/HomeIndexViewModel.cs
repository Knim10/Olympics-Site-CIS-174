using Microsoft.AspNetCore.Mvc;

namespace OlympicGamesSite.Models
{
    public class HomeIndexViewModel
    {
        public string GameFilter { get; set; } = "ALL";
        public string CategoryFilter { get; set; } = "ALL";
    }
}
