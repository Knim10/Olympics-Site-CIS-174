using Microsoft.AspNetCore.Mvc;
using OlympicGamesSite.Models;

namespace OlympicGamesSite.Data
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
        void Save();
    }
}
