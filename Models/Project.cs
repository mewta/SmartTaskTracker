using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.API.Models;

public class Project
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = "Active";

    // 🔗 Relationship
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public List<TaskItem> Tasks { get; set; } = new();
}

