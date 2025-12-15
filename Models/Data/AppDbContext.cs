using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.API.Models;

namespace SmartTaskTracker.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
}
