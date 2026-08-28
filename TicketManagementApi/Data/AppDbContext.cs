using Microsoft.EntityFrameworkCore;
using TicketManagementApi.Models;

namespace TicketManagementApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Ticket> Tickets { get; set; } 
    }
}
