using EBoxOffice.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetTickets();
        Task<TicketDTO> GetById(int? id);
        Task Add(TicketDTO ticketDto);
        Task Update(TicketDTO ticketDto);
        Task Remove(int? id);
    }
}
