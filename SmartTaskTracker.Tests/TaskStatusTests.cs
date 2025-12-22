using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.Models;
using Xunit;

public class TaskStatusTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TaskStatusTestDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void Update_Task_Status_To_Completed_Works()
    {
        // Arrange
        var db = GetDbContext();

        var task = new TaskItem
        {
            Title = "Test Task",
            Status = "Pending",
            ProjectId = 1
        };

        db.Tasks.Add(task);
        db.SaveChanges();

        // Act
        task.Status = "Completed";
        db.SaveChanges();

        // Assert
        var updatedTask = db.Tasks.First();
        Assert.Equal("Completed", updatedTask.Status);
    }
}
