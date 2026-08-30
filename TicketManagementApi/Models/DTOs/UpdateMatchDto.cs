namespace TicketManagementApi.Models.DTOs
{
    public class UpdateMatchDto
    {
        public string HomeTeam { get; set; } = string.Empty;

        public string AwayTeam { get; set; } = string.Empty;

         public DateTime MatchDate { get; set; }

        public Guid StadiumId { get; set; }
        public MatchStatus Status {get;set; }
    }
}
