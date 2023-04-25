using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using EBoxOffice.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext _eventContext;
        public EventRepository(ApplicationDbContext context)
        {
            _eventContext = context;
        }

        public async Task<Event> CreateAsync(Event @event)
        {
            _eventContext.Add(@event);
            await _eventContext.SaveChangesAsync();
            return @event;
        }

        public async Task<Event> GetByIdAsync(int? id)
        {
            return await _eventContext.Events.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _eventContext.Events.ToListAsync();
        }

        public async Task<Event> RemoveAsync(Event @event)
        {
            _eventContext.Remove(@event);
            await _eventContext.SaveChangesAsync();
            return @event;
        }

        public async Task<Event> UpdateAsync(Event @event)
        {
            _eventContext.Update(@event);
            await _eventContext.SaveChangesAsync();
            return @event;
        }
    }
}
