using AutoMapper;
using TicketManagementApi.Data;
using TicketManagementApi.Models;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace TicketManagementApi.Services
{
    public class MatchService : IMatch
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MatchService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MatchDto> CreateMatchAsync(CreateMatchDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            match.Id = Guid.NewGuid();
            match.CreatedAt = DateTime.UtcNow;
            match.Status = MatchStatus.Upcoming;

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return _mapper.Map<MatchDto>(dto);
        }

        public async Task<bool> DeleteMatchByIdAsync(Guid Id)
        {
            var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == Id);
            if(match == null) return false;
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return false;

        }

        public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
        {
            var matches = await _context.Matches.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }

        public async Task<MatchDto> GetMatchByIdAsync(Guid Id)
        {
           var match = await _context.Matches.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Id);
            if(match == null) return null;
            return _mapper.Map<MatchDto>(match);
        }

        public async Task<MatchDto> UpdateMatchByIdAsync(UpdateMatchDto dto, Guid Id)
        {
             var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == Id);
             if(match == null) return null;
             _mapper.Map(dto, match);
             await _context.SaveChangesAsync();
            return _mapper.Map<MatchDto>(match);
        }
    }
}
