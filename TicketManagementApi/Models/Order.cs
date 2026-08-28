namespace TicketManagementApi.Models
{
    public class Order
    {
        public Guid Id { get;set;}
        public Guid UserId { get;set;}
        public User User { get;set;} = null!;
        public DateTime OrderDate { get;set;}
        public decimal TotalAmount { get;set;}
        public ICollection<Order> Orders { get;set;} = new List<Order>();
        public enum Status { }

    }
}
 