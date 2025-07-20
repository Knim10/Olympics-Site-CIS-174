using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OlympicGamesSite.Models;

namespace OlympicGamesSite.Data
{
    public class OlympicsDbContext : IdentityDbContext
    {
        public OlympicsDbContext(DbContextOptions<OlympicsDbContext> options)
            : base(options) { }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call IdentityDbContext to set up Identity tables
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sport>().HasData(
                new Sport { Id = 1, Country = "Austria", Game = "Paralympics", SportName = "Canoe Sprint", Category = "Outdoor" },
                new Sport { Id = 2, Country = "Brazil", Game = "Summer Olympics", SportName = "Road Cycling", Category = "Outdoor" },
                new Sport { Id = 3, Country = "Canada", Game = "Winter Olympics", SportName = "Curling", Category = "Indoor" },
                new Sport { Id = 4, Country = "China", Game = "Summer Olympics", SportName = "Diving", Category = "Indoor" },
                new Sport { Id = 5, Country = "Cyprus", Game = "Youth Olympic Games", SportName = "Breakdancing", Category = "Indoor" },
                new Sport { Id = 6, Country = "Finland", Game = "Youth Olympic Games", SportName = "Skateboarding", Category = "Outdoor" },
                new Sport { Id = 7, Country = "France", Game = "Youth Olympic Games", SportName = "Breakdancing", Category = "Indoor" },
                new Sport { Id = 8, Country = "Germany", Game = "Summer Olympics", SportName = "Diving", Category = "Indoor" },
                new Sport { Id = 9, Country = "Great Britain", Game = "Winter Olympics", SportName = "Curling", Category = "Indoor" },
                new Sport { Id = 10, Country = "Italy", Game = "Winter Olympics", SportName = "Bobsleigh", Category = "Outdoor" },
                new Sport { Id = 11, Country = "Jamaica", Game = "Winter Olympics", SportName = "Bobsleigh", Category = "Outdoor" },
                new Sport { Id = 12, Country = "Japan", Game = "Winter Olympics", SportName = "Bobsleigh", Category = "Outdoor" },
                new Sport { Id = 13, Country = "Mexico", Game = "Summer Olympics", SportName = "Diving", Category = "Indoor" },
                new Sport { Id = 14, Country = "Netherlands", Game = "Summer Olympics", SportName = "Cycling", Category = "Outdoor" },
                new Sport { Id = 15, Country = "Pakistan", Game = "Paralympics", SportName = "Canoe Sprint", Category = "Outdoor" },
                new Sport { Id = 16, Country = "Portugal", Game = "Youth Olympic Games", SportName = "Skateboarding", Category = "Outdoor" },
                new Sport { Id = 17, Country = "Russia", Game = "Youth Olympic Games", SportName = "Breakdancing", Category = "Indoor" },
                new Sport { Id = 18, Country = "Slovakia", Game = "Youth Olympic Games", SportName = "Skateboarding", Category = "Outdoor" },
                new Sport { Id = 19, Country = "Sweden", Game = "Winter Olympics", SportName = "Curling", Category = "Indoor" },
                new Sport { Id = 20, Country = "Thailand", Game = "Paralympics", SportName = "Archery", Category = "Indoor" },
                new Sport { Id = 21, Country = "Ukraine", Game = "Paralympics", SportName = "Archery", Category = "Indoor" },
                new Sport { Id = 22, Country = "Uruguay", Game = "Paralympics", SportName = "Archery", Category = "Indoor" },
                new Sport { Id = 23, Country = "USA", Game = "Summer Olympics", SportName = "Road Cycling", Category = "Outdoor" },
                new Sport { Id = 24, Country = "Zimbabwe", Game = "Paralympics", SportName = "Canoe Sprint", Category = "Outdoor" }
            );
        }
    }
}
