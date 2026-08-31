using TicketManagementApi.Models.DTOs;

namespace TicketManagementApi.Services.IServices
{
    public interface ITicket
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task<TicketDto> GetTicketByIdAsync(Guid Id);
        Task<TicketDto> CreateTicketAsync(CreateTicketDto dto);
        Task<TicketDto> UpdatedTicketByIdAsync(UpdateTicketDto dto, Guid Id);
        Task<bool> DeleteTicketByIdAsync(Guid Id);

    }
}
