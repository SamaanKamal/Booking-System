using Booking_System.Data;
using Booking_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Repositories.BookingRepository
{
    public class BookingRepositoryImp : IBookingRepository
    {
        private readonly BookingSystemContext _context;

        public BookingRepositoryImp(BookingSystemContext bookingSystemContext) {
            _context = bookingSystemContext;
        }
        public async Task<Booking> AddBookingAsync(Booking booking)
        {
           await _context.Bookings.AddAsync(booking);
           await _context.SaveChangesAsync();
           return booking;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByResourceAndDateRangeAsync(int resourceId, DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings.Where(booking => booking.ResourceId == resourceId&& (booking.StartTime < endDate &&booking.EndTime > startDate)).ToListAsync();
        }
    }
}
