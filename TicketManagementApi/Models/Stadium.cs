namespace TicketManagementApi.Models
{
    public class Stadium
    {
        public Guid Id {get;set; }
        public string Name { get;set;} = string.Empty;
        public string Location { get;set;} = string.Empty;
        public int Capacity { get;set;}
    }

}