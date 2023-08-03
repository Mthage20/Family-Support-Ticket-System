using FamilyTicketSupportSystem.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    string connectionString = "Server=localhost;Database=TicketSystem;User=root;Password=;";

    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)));
    }
}
