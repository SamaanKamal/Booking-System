using Booking_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Data
{
    public class BookingSystemContext:DbContext
    {
        public BookingSystemContext(DbContextOptions<BookingSystemContext> options) : base(options) {

        }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
