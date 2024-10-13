using Booking_System.DTO;
using Booking_System.Model;

namespace Booking_System.Services.BookingService
{
    public interface IBookingService
    {
        Task<(bool IsAvailable, string Message)> IsBookingAvailableAsync(BookingRequestDTO bookingRequest);
        Task<Booking> CreateBookingAsync(BookingRequestDTO bookingRequest);
    }
}
