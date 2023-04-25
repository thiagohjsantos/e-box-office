using EBoxOffice.Domain.Entities;
using MediatR;

namespace EBoxOffice.Application.Events.Queries
{
    public class GetEventByIdQuery : IRequest<Event>
    {
        public int Id { get; set; }

        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
