using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> Get()
        {
            var events = await _eventService.GetEvents();
            if (events == null)
            {
                return NotFound("Events not found");
            }
            return Ok(events);
        }

        [HttpGet("{id:int}", Name = "GetEvent")]
        public async Task<ActionResult<EventDTO>> Get(int id)
        {
            var events = await _eventService.GetById(id);
            if (events == null)
            {
                return NotFound("Event not found");
            }
            return Ok(events);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventDTO eventDto)
        {
            if (eventDto == null)
                return BadRequest("Invalid data");

            await _eventService.Add(eventDto);

            return new CreatedAtRouteResult("GetEvent", new { id = eventDto.Id },
                eventDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EventDTO eventDto)
        {
            if (id != eventDto.Id)
                return BadRequest();

            if (eventDto == null)
                return BadRequest();

            await _eventService.Update(eventDto);

            return Ok(eventDto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventDTO>> Delete(int id)
        {
            var events = await _eventService.GetById(id);
            if (events == null)
            {
                return NotFound("Event not found");
            }

            await _eventService.Remove(id);

            return Ok(events);

        }
    }
}
