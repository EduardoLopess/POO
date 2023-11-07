using AutoMapper;
using backend.Models.Domain.Entities;
using backend.Models.Domain.ViewModels;

namespace backend.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
             CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.GenderViewModel))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.AddressViewModel));

            CreateMap<AddressViewModel, Address>();
        }
    }
}