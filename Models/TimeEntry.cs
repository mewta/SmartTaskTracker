namespace SmartTaskTracker.API.Models;

public class TimeEntry
{
    public int Id { get; set; }
    public double Hours { get; set; }
    public DateTime Date { get; set; }

    public int TaskItemId { get; set; }
    public TaskItem TaskItem { get; set; } = null!;
}
