namespace SmartTaskTracker.API.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Status { get; set; } = "Pending";

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public List<TimeEntry> TimeEntries { get; set; } = new();
}
