namespace FarmAPI.DTOs;

public class CreateFarmDTO
{
    public required string Owner { get; set; }
    public int Capacity { get; set; }
    public int ReadyProducts { get; set; }
    public int UsedSpace { get; set; }
    public Guid? CurrentPlantId { get; set; }
}
