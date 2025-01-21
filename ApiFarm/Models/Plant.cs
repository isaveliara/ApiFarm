namespace FarmAPI.Models;

public class Plant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Season { get; set; } //enum para fazer a validação
    public bool KeepOnCollect { get; set; }
    public int SpaceRequired { get; set; } = 1;
    public int GrowthTime { get; set; }
    public int Value { get; set; }
    public List<string> RequiredAchievements { get; set; } = new();
}
