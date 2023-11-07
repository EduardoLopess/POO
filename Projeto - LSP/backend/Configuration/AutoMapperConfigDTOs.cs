using AutoMapper;
using backend.Models.Domain.DTOs;
using backend.Models.Domain.Entities;

namespace backend.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, map => map.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.AddressDTO, map => map.MapFrom(src => src.Addresses));

            CreateMap<Address, AddressDTO>();    
        }
    }
}