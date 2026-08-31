namespace TicketManagementApi.Models.DTOs
{
    public class TicketDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid TicketTypeId { get; set; }

        public string QrCode { get; set; } = string.Empty;

        public int TicketNumber { get; set; }

        public TicketStatus Status { get; set; }

        public DateTime PurchasedAt { get; set; }
    }
}
