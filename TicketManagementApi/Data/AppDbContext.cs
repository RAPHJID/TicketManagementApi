using Microsoft.EntityFrameworkCore;
using TicketManagementApi.Models;

namespace TicketManagementApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Match> Matches { get; set; }

    public DbSet<Stadium> Stadiums { get; set; }

    public DbSet<TicketType> TicketTypes { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Ticket> Tickets { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Match>()
            .HasOne(m => m.Stadium)
            .WithMany(s => s.Matches)
            .HasForeignKey(m => m.StadiumId);

        modelBuilder.Entity<TicketType>()
            .HasOne(t => t.Match)
            .WithMany(m => m.TicketTypes)
            .HasForeignKey(t => t.MatchId);


        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Order)
            .WithMany(o => o.Tickets)
            .HasForeignKey(t => t.OrderId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.TicketType)
            .WithMany(tt => tt.Tickets)
            .HasForeignKey(t => t.TicketTypeId);


        // Decimal precision
        modelBuilder.Entity<TicketType>()
            .Property(t => t.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);
    }
}