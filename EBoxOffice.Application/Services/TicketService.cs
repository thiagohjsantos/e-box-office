using AutoMapper;
using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Interfaces;
using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBoxOffice.Application.Services
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository ??
                throw new ArgumentNullException(nameof(ticketRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDTO>> GetTickets()
        {
            var ticketsEntity = await _ticketRepository.GetTicketsAsync();
            return _mapper.Map<IEnumerable<TicketDTO>>(ticketsEntity);

        }

        public async Task<TicketDTO> GetById(int? id)
        {
            var ticketsEntity = await _ticketRepository.GetByIdAsync(id);
            return _mapper.Map<TicketDTO>(ticketsEntity);

        }

        public async Task Add(TicketDTO ticketDto)
        {
            var ticketsEntity = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.CreateAsync(ticketsEntity);

        }

        public async Task Update(TicketDTO ticketDto)
        {
            var ticketsEntity = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.UpdateAsync(ticketsEntity);

        }

        public async Task Remove(int? id)
        {
            var ticketsEntity = _ticketRepository.GetByIdAsync(id).Result;
            await _ticketRepository.RemoveAsync(ticketsEntity);

        }
    }
}
