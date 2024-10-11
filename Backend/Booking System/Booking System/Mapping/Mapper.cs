using AutoMapper;
using Booking_System.DTO;
using Booking_System.Model;

namespace Booking_System.Mapping
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Resource, ResourceRequestDTO>().ReverseMap();
            CreateMap<Booking, BookingRequestDTO>().ReverseMap();
        }
    }
}
