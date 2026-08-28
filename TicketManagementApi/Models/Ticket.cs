namespace TicketManagementApi.Models
{
    public class Ticket
    {
        public Guid Id { get;set;}
        public Guid TicketTypeId { get;set;}
        public TicketType TicketType { get;set;} = null!;
        public Guid OrderId { get;set;}
        public Order Order { get;set;} = null!;
        public string QrCode { get;set;} = string.Empty;
        public int TicketNumber { get;set;}
        public enum Status { }
        public DateTime PurchasedAt { get;set;}
    }
}
