namespace TicketManagementApi.Models.DTOs
{
    public class CreateTicketDto
    {
        public Guid OrderId { get; set; }

        public Guid TicketTypeId { get; set; }
    }
}
