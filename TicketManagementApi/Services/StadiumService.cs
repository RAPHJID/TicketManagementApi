using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketManagementApi.Data;
using TicketManagementApi.Models;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;

namespace TicketManagementApi.Services
{
    public class StadiumService : IStadium
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StadiumService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StadiumDto> CreateStadiumAsync(CreateUpdateStadiumDto dto)
        {
            var stadium = _mapper.Map<Stadium>(dto);
            await _context.Stadiums.AddAsync(stadium);
            await _context.SaveChangesAsync();
            return _mapper.Map<StadiumDto>(stadium);
        }

        public async Task<bool> DeleteStadiumByIdAsync(Guid Id)
        {
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Id == Id);
            if(stadium == null) return false;
            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();
            return false;
        }

        public async Task<StadiumDto> GetAllStadiumsAsync()
        {
            var stadiums = await _context.Stadiums.ToListAsync();
            return _mapper.Map<StadiumDto>(stadiums);
        }

        public async Task<StadiumDto> GetStadiumByIdAsync(Guid Id)
        {
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Id == Id);
            if(stadium == null)  return null;
            return _mapper.Map<StadiumDto>(stadium);
        }

        public async Task<StadiumDto> UpdateStadiumByIdAsync(CreateUpdateStadiumDto dto, Guid Id)
        {
           var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Id == Id);
            if(stadium == null)  return null;
            _mapper.Map(dto, stadium);
            await _context.SaveChangesAsync();
            return _mapper.Map<StadiumDto>(stadium);
        }
    }
}
