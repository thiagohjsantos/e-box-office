using EBoxOffice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<Ticket> GetByIdAsync(int? id);
        Task<Ticket> CreateAsync(Ticket product);
        Task<Ticket> UpdateAsync(Ticket product);
        Task<Ticket> RemoveAsync(Ticket product);
    }
}
