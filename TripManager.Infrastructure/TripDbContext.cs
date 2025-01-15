using Microsoft.EntityFrameworkCore;
using TripManager.Infrastructure.Entities;

namespace TripManager.Infrastructure;

public class TripDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = C:\\Users\\maria\\Downloads\\JourneyDatabase.db");
    }
}
