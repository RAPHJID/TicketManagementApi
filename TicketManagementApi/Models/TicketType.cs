namespace TicketManagementApi.Models
{
    public class TicketType
    {
        public Guid Id { get;set;}
        public Guid MatchId { get;set;}
        public string Name { get;set;} = string.Empty;
        public decimal Price { get;set;}
        public int Quantity { get;set;}
        public int AvailableQuantity { get;set;}

    }
}
