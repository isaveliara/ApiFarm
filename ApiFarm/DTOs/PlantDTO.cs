namespace FarmAPI.DTOs;

public class PlantDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Season { get; set; }
    public int SpaceRequired { get; set; }
    public int GrowthTime { get; set; }
    public int Value { get; set; }
    public required List<string> RequiredAchievements { get; set; }
}
