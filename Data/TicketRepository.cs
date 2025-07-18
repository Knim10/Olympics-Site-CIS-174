using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Models;

namespace OlympicGamesSite.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly OlympicsDbContext _context;

        public TicketRepository(OlympicsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAll() => _context.Tickets.ToList();

        public Ticket Get(int id) => _context.Tickets.Find(id);

        public void Add(Ticket ticket) => _context.Tickets.Add(ticket);

        public void Update(Ticket ticket) => _context.Tickets.Update(ticket);

        public void Delete(int id)
        {
            var ticket = Get(id);
            if (ticket != null) _context.Tickets.Remove(ticket);
        }

        public void Save() => _context.SaveChanges();
    }

}
