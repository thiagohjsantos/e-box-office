using AutoMapper;
using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Events.Commands;

namespace EBoxOffice.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<EventDTO, EventCreateCommand>();
            CreateMap<EventDTO, EventUpdateCommand>();
        }
    }
}
