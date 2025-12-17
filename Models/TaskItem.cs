using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.API.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string Status { get; set; } = "Pending";

    // 🔗 Relationship
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}
