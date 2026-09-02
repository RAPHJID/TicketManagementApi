using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketManagementApi.Data;
using TicketManagementApi.Models;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;

namespace TicketManagementApi.Services
{
    public class TicketService : ITicket
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TicketDto> CreateTicketAsync(CreateTicketDto dto)
        {
            var ticket = _mapper.Map<Ticket>(dto);
            ticket.Id = Guid.NewGuid();
            ticket.Status = TicketStatus.Active;
            ticket.PurchasedAt = DateTime.UtcNow;
            ticket.TicketNumber = await _context.Tickets.CountAsync() + 1;
            ticket.QrCode = Guid.NewGuid().ToString();
            
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return _mapper.Map<TicketDto>(ticket);

        }

        public async Task<bool> DeleteTicketByIdAsync(Guid Id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);
            if(ticket == null) return false;
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> GetTicketByIdAsync(Guid Id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);
            if(ticket == null) return null;
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<TicketDto> UpdatedTicketByIdAsync(UpdateTicketDto dto, Guid Id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);
            if(ticket == null) return null;
            _mapper.Map(dto, ticket);
            await _context.SaveChangesAsync();
            return _mapper.Map<TicketDto>(ticket);
        }
    }
}
