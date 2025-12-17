using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace SmartTaskTracker.API.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=127.0.0.1,1433;Database=SmartTaskDb;User Id=sa;Password=Task@1234;TrustServerCertificate=True;"
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}


