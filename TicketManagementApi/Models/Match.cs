namespace TicketManagementApi.Models;

public class Match
{
    public Guid Id { get; set; }

    public string HomeTeam { get; set; } = string.Empty;

    public string AwayTeam { get; set; } = string.Empty;

    public DateTime MatchDate { get; set; }

    // Foreign Key
    public Guid StadiumId { get; set; }

    // Navigation property
    public Stadium Stadium { get; set; } = null!;

    public MatchStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation property
    public ICollection<TicketType> TicketTypes { get; set; }
        = new List<TicketType>();
}

public enum MatchStatus
{
    Upcoming,
    Ongoing,
    Completed,
    Cancelled
}