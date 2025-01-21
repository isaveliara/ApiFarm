namespace FarmAPI.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public ulong Level { get; set; }
    public ulong Money { get; set; }
    public float Popularity { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public List<string> Achievements { get; set; } = new();
    public required List<Farm> Farms { get; set; }
}
