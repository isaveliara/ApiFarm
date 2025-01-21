namespace FarmAPI.Models;

public class Farm
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public required string Owner { get; set; }
    public int Capacity { get; set; }
    public int ReadyProducts { get; set; }
    public int UsedSpace { get; set; }
    public Guid? CurrentPlantId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required Plant CurrentPlant { get; set; }
}
