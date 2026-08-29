namespace TicketManagementApi.Models;

public class Order
{
    public Guid Id { get; set; }

    // Foreign Key
    public Guid UserId { get; set; }

    // Navigation property
    public User User { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }

    // Navigation property
    public ICollection<Ticket> Tickets { get; set; }
        = new List<Ticket>();
}

public enum OrderStatus
{
    Pending,
    Paid,
    Cancelled,
    Refunded
}