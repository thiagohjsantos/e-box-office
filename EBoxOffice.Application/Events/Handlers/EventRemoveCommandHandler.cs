using EBoxOffice.Application.Events.Commands;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Events.Handlers
{
    public class EventRemoveCommandHandler : IRequestHandler<EventRemoveCommand, Event>
    {
        private readonly IEventRepository _eventRepository;

        public EventRemoveCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ??
                throw new ArgumentNullException(nameof(eventRepository));
        }

        public async Task<Event> Handle(EventRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var eventObject = await _eventRepository.GetByIdAsync(request.Id);

            if (eventObject == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                return await _eventRepository.RemoveAsync(eventObject);
            }
        }
    }
}
