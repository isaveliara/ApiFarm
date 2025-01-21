namespace FarmAPI.DTOs;
public class FarmDTO
{
    public Guid Id { get; set; }
    public required string Owner { get; set; }
    public int Capacity { get; set; }
    public int ReadyProducts { get; set; }
    public int UsedSpace { get; set; }
    public required string CurrentPlant { get; set; }
}
