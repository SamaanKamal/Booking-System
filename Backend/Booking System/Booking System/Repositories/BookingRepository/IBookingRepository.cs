using Booking_System.Model;

namespace Booking_System.Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByResourceAndDateRangeAsync(int resourceId, DateTime startDate, DateTime endDate);
        Task<Booking> AddBookingAsync(Booking booking);
    }
}
