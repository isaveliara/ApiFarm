namespace FarmAPI.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ulong Level { get; set; }
    public ulong Money { get; set; }
    public float Popularity { get; set; }
    public required List<FarmDTO> Farms { get; set; }
}
