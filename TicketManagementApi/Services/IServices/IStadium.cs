using TicketManagementApi.Models.DTOs;

namespace TicketManagementApi.Services.IServices
{
    public interface IStadium
    {
        Task<StadiumDto> GetAllStadiumsAsync();
        Task<StadiumDto> GetStadiumByIdAsync(Guid Id);
        Task<StadiumDto> CreateStadiumAsync(CreateUpdateStadiumDto dto);
        Task<StadiumDto> UpdateStadiumByIdAsync(CreateUpdateStadiumDto dto, Guid Id);
        Task<bool> DeleteStadiumByIdAsync(Guid Id);
    }
}
