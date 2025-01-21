namespace FarmAPI.DTOs;

public class CreatePlantDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Season { get; set; }
    public int SpaceRequired { get; set; }
    public int GrowthTime { get; set; }
    public int Value { get; set; }
}
