using Booking_System.DTO;
using Booking_System.Model;

namespace Booking_System.Services.BookingService
{
    public interface IBookingService
    {
        Task<bool> IsBookingAvailableAsync(BookingRequestDTO bookingRequest);
        Task<Booking> CreateBookingAsync(BookingRequestDTO bookingRequest);
    }
}
