using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.DTOs.TimeEntries;
using SmartTaskTracker.API.Models;

namespace SmartTaskTracker.API.Controllers;

[ApiController]
[Authorize]
[Route("api/tasks/{taskId}/time-entries")]
public class TimeEntriesController : ControllerBase
{
    private readonly AppDbContext _db;

    public TimeEntriesController(AppDbContext db)
    {
        _db = db;
    }

    // POST /api/tasks/{taskId}/time-entries
    [HttpPost]
    public IActionResult AddTimeEntry(int taskId, CreateTimeEntryDto dto)
    {
        var task = _db.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
            return NotFound("Task not found");

        var entry = new TimeEntry
        {
            TaskItemId = taskId,
            Hours = dto.Hours
        };

        _db.TimeEntries.Add(entry);
        _db.SaveChanges();

        return Ok("Time entry added");
    }

    // GET /api/tasks/{taskId}/time-entries
    [HttpGet]
    public IActionResult GetTimeEntries(int taskId)
    {
        var entries = _db.TimeEntries
            .Where(t => t.TaskItemId == taskId)
            .Select(t => new TimeEntryDto
            {
                Id = t.Id,
                Hours = t.Hours,
                Date = t.Date
            })
            .ToList();

        return Ok(entries);
    }

    // GET /api/tasks/{taskId}/time-entries/total-hours
    [HttpGet("total-hours")]
    public IActionResult GetTotalHours(int taskId)
    {
        var totalHours = _db.TimeEntries
            .Where(t => t.TaskItemId == taskId)
            .Sum(t => t.Hours);

        return Ok(new { taskId, totalHours });
    }
}


