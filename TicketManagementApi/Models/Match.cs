namespace TicketManagementApi.Models
{
    public class Match
    {
        public Guid Id { get;set;}
        public string HomeTeam { get;set;} = string.Empty;
        public string AwayTeam { get;set;} = string.Empty;
        public DateTime MatchDate { get;set;}
        public Guid StadiumId { get;set;}
        public enum Status { };
        public DateTime CreatedAt { get;set;}

    }
}

