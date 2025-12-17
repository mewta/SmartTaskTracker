using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTaskTracker.API.Models;

public class TimeEntry
{
    [Key]
    public int Id { get; set; }

    public int TaskItemId { get; set; }

    [ForeignKey(nameof(TaskItemId))]
    public TaskItem TaskItem { get; set; } = null!;

    public double Hours { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
}

