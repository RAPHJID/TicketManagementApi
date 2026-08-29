namespace TicketManagementApi.Models;

public class Ticket
{
    public Guid Id { get; set; }

    // Foreign Key
    public Guid OrderId { get; set; }

    // Navigation property
    public Order Order { get; set; } = null!;

    // Foreign Key
    public Guid TicketTypeId { get; set; }

    // Navigation property
    public TicketType TicketType { get; set; } = null!;

    public string QrCode { get; set; } = string.Empty;

    public int TicketNumber { get; set; }

    public TicketStatus Status { get; set; }

    public DateTime PurchasedAt { get; set; }
}

public enum TicketStatus
{
    Active,
    Used,
    Cancelled
}