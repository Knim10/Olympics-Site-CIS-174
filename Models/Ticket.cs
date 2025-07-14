using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OlympicGamesSite.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Range(1, 20, ErrorMessage = "Sprint number must be between 1 and 20")]
        public int SprintNumber { get; set; }

        [Range(1, 100, ErrorMessage = "Point value must be between 1 and 100")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "To Do";
    }

}
