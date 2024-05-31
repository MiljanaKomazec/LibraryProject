using AutoMapper;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Profiles
{
    public class BookRentProfile : Profile
    {
        public BookRentProfile() {
            CreateMap<BookRent, RentHistoryUserDTO>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
                .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate))
                .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
                .ReverseMap();
            CreateMap<BookRent, RentHistoryBookDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate))
                .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
                .ReverseMap();
            CreateMap<BookRent, BookRentDTO>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate))
                .ForMember(dest => dest.RentalPeriodInDays, opt => opt.MapFrom(src => src.RentalPeriodInDays))
                .ReverseMap();
            CreateMap<BookRent, BookReturnDTO>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
                .ReverseMap();
        }
    }
}
