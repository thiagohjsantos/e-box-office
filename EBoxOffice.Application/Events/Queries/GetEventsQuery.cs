using EBoxOffice.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace EBoxOffice.Application.Events.Queries
{
    public class GetEventsQuery : IRequest<IEnumerable<Event>>
    {
    }
}
