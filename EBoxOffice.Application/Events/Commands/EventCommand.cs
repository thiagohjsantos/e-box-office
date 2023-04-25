using EBoxOffice.Domain.Entities;
using MediatR;
using System;

namespace EBoxOffice.Application.Events.Commands
{
    public abstract class EventCommand : IRequest<Event>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }

    }
}
