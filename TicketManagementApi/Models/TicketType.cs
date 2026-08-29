namespace TicketManagementApi.Models;

public class TicketType
{
    public Guid Id { get; set; }

    // Foreign Key
    public Guid MatchId { get; set; }

    // Navigation property
    public Match Match { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int AvailableQuantity { get; set; }

    // Navigation property
    public ICollection<Ticket> Tickets { get; set; }
        = new List<Ticket>();
}