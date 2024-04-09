using Microsoft.EntityFrameworkCore;

namespace DriverTest.Models;

public class DriverTestContext : DbContext
{
    public DriverTestContext(DbContextOptions<DriverTestContext> options)
        : base(options)
    {
    }

    
    public DbSet<Results> Results { get; set; }
}