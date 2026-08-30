using TicketManagementApi.Models.DTOs;

namespace TicketManagementApi.Services.IServices
{
    public interface IMatch
    {
        Task <IEnumerable<MatchDto>> GetAllMatchesAsync();
        Task<MatchDto> GetMatchByIdAsync(Guid Id);
        Task<MatchDto> CreateMatchAsync(CreateMatchDto dto);
        Task<MatchDto> UpdateMatchByIdAsync(UpdateMatchDto dto, Guid Id);
        Task<bool> DeleteMatchByIdAsync(Guid Id);
    }
}
