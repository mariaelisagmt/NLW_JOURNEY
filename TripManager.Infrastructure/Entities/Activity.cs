using TripManager.Infrastructure.Enums;

namespace TripManager.Infrastructure.Entities;

public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;
    public Guid TripId { get; set; }
}
