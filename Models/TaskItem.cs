
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem_73464.Models;

public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3
}

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public int AppUserId { get; set; }

    public AppUser? AppUser { get; set; }
}
