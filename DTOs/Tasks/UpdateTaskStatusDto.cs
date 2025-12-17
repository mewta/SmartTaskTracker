using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.API.DTOs.Tasks;

public class UpdateTaskStatusDto
{
    [Required]
    public string Status { get; set; } = "Pending";
}
