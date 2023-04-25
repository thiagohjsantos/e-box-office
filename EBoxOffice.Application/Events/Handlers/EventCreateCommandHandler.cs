using EBoxOffice.Application.Events.Commands;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Events.Handlers
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, Event>
    {
        private readonly IEventRepository _eventRepository;

        public EventCreateCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(EventCreateCommand request,
            CancellationToken cancellationToken)
        {
            var eventObject = new Event(request.Name, request.Description, request.Image, request.Date);

            if (eventObject == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                eventObject.CategoryId = request.CategoryId;
                return await _eventRepository.CreateAsync(eventObject);
            }
        }
    }
}
