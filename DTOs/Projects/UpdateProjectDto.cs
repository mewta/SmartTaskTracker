using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.API.DTOs.Projects;

public class UpdateProjectDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public string Status { get; set; } = "Active"; // Active / Completed
}
