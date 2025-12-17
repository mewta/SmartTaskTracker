using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.DTOs.Projects;
using SmartTaskTracker.API.Models;
using System.Security.Claims;

namespace SmartTaskTracker.API.Controllers;

[Authorize]
[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProjectsController(AppDbContext db)
    {
        _db = db;
    }

    // POST: api/projects
    [HttpPost]
    public IActionResult CreateProject(CreateProjectDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            UserId = userId
        };

        _db.Projects.Add(project);
        _db.SaveChanges();

        return Ok(project);
    }

    // GET: api/projects
    [HttpGet]
    public IActionResult GetMyProjects()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var projects = _db.Projects
            .Where(p => p.UserId == userId)
            .ToList();

        return Ok(projects);
    }
    [HttpPut("{id}")]
 public IActionResult UpdateProject(int id, UpdateProjectDto dto)
  {
    var project = _db.Projects.FirstOrDefault(p => p.Id == id);
    if (project == null)
        return NotFound("Project not found");

    project.Name = dto.Name;
    project.Description = dto.Description;
    project.Status = dto.Status;

    _db.SaveChanges();

    return Ok("Project updated successfully");
  }

}

