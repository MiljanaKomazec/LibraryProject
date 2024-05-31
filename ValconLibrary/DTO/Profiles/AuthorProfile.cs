using AutoMapper;
using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
            CreateMap<Author, AuthorCreateDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => src.YearOfBirth))
                .ReverseMap();
            CreateMap<Author, AuthorUpdateDTO>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => src.YearOfBirth))
                .ReverseMap();
            CreateMap<Author, AuthorDTO>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => src.YearOfBirth))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ReverseMap();
        }
    }
}
