using AutoMapper;
using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.NumberOfPages, opt => opt.MapFrom(src => src.NumberOfPages))
                .ForMember(dest => dest.PublishingYear, opt => opt.MapFrom(src => src.PublishingYear))
                .ForMember(dest => dest.TotalCopies, opt => opt.MapFrom(src => src.TotalCopies))
                .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ReverseMap();
            CreateMap<Book, BookUpdateDTO>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.PublishingYear, opt => opt.MapFrom(src => src.PublishingYear))
                .ForMember(dest => dest.TotalCopies, opt => opt.MapFrom(src => src.TotalCopies))
                .ReverseMap();
            CreateMap<Book, BookRentHistoryDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.NumberOfPages, opt => opt.MapFrom(src => src.NumberOfPages))
                .ForMember(dest => dest.PublishingYear, opt => opt.MapFrom(src => src.PublishingYear))
                .ForMember(dest => dest.TotalCopies, opt => opt.MapFrom(src => src.TotalCopies))
                .ReverseMap();

        }
    }
}
