using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using EBoxOffice.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private ApplicationDbContext _ticketContext;
        public TicketRepository(ApplicationDbContext context)
        {
            _ticketContext = context;
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            _ticketContext.Add(ticket);
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetByIdAsync(int? id)
        {
            return await _ticketContext.Tickets.Include(c => c.Event)
                 .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _ticketContext.Tickets.ToListAsync();
        }

        public async Task<Ticket> RemoveAsync(Ticket ticket)
        {
            _ticketContext.Remove(ticket);
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            _ticketContext.Update(ticket);
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }
    }
}
