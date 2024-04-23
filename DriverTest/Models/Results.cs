namespace DriverTest.Models;

public class Results
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int Score { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}