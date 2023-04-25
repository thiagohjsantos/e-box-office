using EBoxOffice.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();
        Task<EventDTO> GetById(int? id);
        Task Add(EventDTO eventDto);
        Task Update(EventDTO eventDto);
        Task Remove(int? id);
    }
}
