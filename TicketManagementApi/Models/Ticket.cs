namespace TicketManagementApi.Models
{
    public class Ticket
    {
        public Guid Id { get;set;}
        public Guid TicketTypeId { get;set;}
        public Guid OrderId { get;set;}
        public string QrCode { get;set;} = string.Empty;
        public int TicketNumber { get;set;}
        public enum Status { }
        public DateTime PurchasedAt { get;set;}
    }
}
