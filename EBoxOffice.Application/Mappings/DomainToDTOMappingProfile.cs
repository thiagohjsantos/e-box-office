using AutoMapper;
using EBoxOffice.Application.DTOs;
using EBoxOffice.Domain.Entities;

namespace EBoxOffice.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();
        }
    }
}
