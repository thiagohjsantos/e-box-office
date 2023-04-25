using EBoxOffice.Application.Events.Commands;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Events.Handlers
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, Event>
    {
        private readonly IEventRepository _eventRepository;

        public EventUpdateCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        }

        public async Task<Event> Handle(EventUpdateCommand request,
            CancellationToken cancellationToken)
        {

            var eventObject = await _eventRepository.GetByIdAsync(request.Id);

            if (eventObject == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                eventObject.Update(request.Name, request.Description, request.Image, request.Date, request.CategoryId);

                return await _eventRepository.UpdateAsync(eventObject);

            }
        }
    }
}
