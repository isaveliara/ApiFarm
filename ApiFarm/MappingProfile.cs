using AutoMapper;
using FarmAPI.DTOs;
using FarmAPI.Models;
namespace FarmAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User <=> UserDTO
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<CreateUserDTO, User>();

        //Farm <=> FarmDTO
        CreateMap<Farm, FarmDTO>()
            .ForMember(dest => dest.CurrentPlant, opt => opt.MapFrom(src => src.CurrentPlant != null ? src.CurrentPlant.Name : null));
        CreateMap<CreateFarmDTO, Farm>();

        //Plant <=> PlantDTO
        CreateMap<Plant, PlantDTO>();
        CreateMap<CreatePlantDTO, Plant>();
    }
}
