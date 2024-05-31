using AutoMapper;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
           CreateMap<User, UserCreateDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
           CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ReverseMap();
            CreateMap<User, UserUpdateProfileDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
            CreateMap<User, UserUpdatePasswordDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
            CreateMap<User, UserRentHistoryDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

        }
    }
}
