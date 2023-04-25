using EBoxOffice.Domain.Entities;
using MediatR;

namespace EBoxOffice.Application.Events.Commands
{
    public class EventRemoveCommand : IRequest<Event>
    {
        public int Id { get; set; }

        public EventRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
