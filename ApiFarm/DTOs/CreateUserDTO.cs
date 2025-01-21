namespace FarmAPI.DTOs;

public class CreateUserDTO
{
    public required string Name { get; set; }
    public ulong Level { get; set; }
    public ulong Money { get; set; }
}
