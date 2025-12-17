using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.DTOs.Tasks;
using SmartTaskTracker.API.Models;

namespace SmartTaskTracker.API.Controllers;

[Authorize]
[ApiController]
[Route("api/projects/{projectId}/tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _db;

    public TasksController(AppDbContext db)
    {
        _db = db;
    }

    // POST: api/projects/{projectId}/tasks
    [HttpPost]
    public IActionResult CreateTask(int projectId, CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            ProjectId = projectId
        };

        _db.Tasks.Add(task);
        _db.SaveChanges();

        return Ok(task);
    }

    // GET: api/projects/{projectId}/tasks
    [HttpGet]
    public IActionResult GetTasks(int projectId)
    {
        var tasks = _db.Tasks
            .Where(t => t.ProjectId == projectId)
            .ToList();

        return Ok(tasks);
    }
    [Authorize]
    [HttpPut("{taskId}/status")]
     public IActionResult UpdateStatus(int taskId, UpdateTaskStatusDto dto)
     {
       var task = _db.Tasks.FirstOrDefault(t => t.Id == taskId);

       if (task == null)
        return NotFound("Task not found");

    task.Status = dto.Status;
    _db.SaveChanges();

    return Ok("Task status updated");
     } 
}


