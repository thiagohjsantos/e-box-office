using AutoMapper;
using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Events.Commands;
using EBoxOffice.Application.Events.Queries;
using EBoxOffice.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EventService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;

        }

        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            var eventsQuery = new GetEventsQuery();

            if (eventsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(eventsQuery);

            return _mapper.Map<IEnumerable<EventDTO>>(result);
        }

        public async Task<EventDTO> GetById(int? id)
        {
            var eventByIdQuery = new GetEventByIdQuery(id.Value);

            if (eventByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(eventByIdQuery);

            return _mapper.Map<EventDTO>(result);
        }

        public async Task Add(EventDTO eventDto)
        {
            var eventCreateCommand = _mapper.Map<EventCreateCommand>(eventDto);
            await _mediator.Send(eventCreateCommand);
        }

        public async Task Update(EventDTO eventDto)
        {
            var eventUpdateCommand = _mapper.Map<EventUpdateCommand>(eventDto);
            await _mediator.Send(eventUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var eventRemoveCommand = new EventRemoveCommand(id.Value);
            if (eventRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(eventRemoveCommand);
        }
    }
}
