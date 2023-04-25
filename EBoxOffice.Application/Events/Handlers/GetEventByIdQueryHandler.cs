using EBoxOffice.Application.Events.Queries;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Events.Handlers
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(GetEventByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _eventRepository.GetByIdAsync(request.Id);
        }
    }
}
