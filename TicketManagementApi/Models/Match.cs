namespace TicketManagementApi.Models
{
    public class Match
    {
        public Guid Id { get;set;}
        public string HomeTeam { get;set;} = string.Empty;
        public string AwayTeam { get;set;} = string.Empty;
        public DateTime MatchDate { get;set;}
        public Guid StadiumId { get;set;}
        public Stadium Stadium { get;set;} =null!;
        public ICollection<TicketType> TicketTypes { get;set;} = new List<TicketType>();
        public enum Status { };
        public DateTime CreatedAt { get;set;}

    }
}

