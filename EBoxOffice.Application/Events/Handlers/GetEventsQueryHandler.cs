using EBoxOffice.Application.Events.Queries;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Events.Handlers
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<Event>> Handle(GetEventsQuery request,
            CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventsAsync();
        }
    }
}
