using AutoMapper;
using Booking_System.DTO;
using Booking_System.Model;

namespace Booking_System.Mapping
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Resource, ResourceRequestDTO>().ReverseMap();
            CreateMap<BookingRequestDTO, Booking>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.Parse(src.EndDate)));

            CreateMap<Booking, BookingRequestDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartTime.ToString("yyyy-MM-ddTHH:mm:ss")))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndTime.ToString("yyyy-MM-ddTHH:mm:ss")));
        }
    }
}
