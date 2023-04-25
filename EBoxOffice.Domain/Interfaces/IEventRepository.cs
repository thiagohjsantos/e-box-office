using EBoxOffice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetByIdAsync(int? id);
        Task<Event> CreateAsync(Event product);
        Task<Event> UpdateAsync(Event product);
        Task<Event> RemoveAsync(Event product);
    }
}
