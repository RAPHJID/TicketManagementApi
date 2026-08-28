namespace TicketManagementApi.Models
{
    public class TicketType
    {
        public Guid Id { get;set;}
        public Guid MatchId { get;set;}
        public Match Match { get;set;} = null!;
        public string Name { get;set;} = string.Empty;
        public decimal Price { get;set;}
        public int Quantity { get;set;}
        public ICollection<Ticket> Tickets { get;set;} = new List<Ticket> ();
        public int AvailableQuantity { get;set;}

    }
}
