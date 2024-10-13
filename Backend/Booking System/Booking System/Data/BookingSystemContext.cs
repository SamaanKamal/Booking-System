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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1, Name = "Laptop", TotalQuantity = 10 },
                new Resource { Id = 2, Name = "Projector", TotalQuantity = 5 },
                new Resource { Id = 3, Name = "Conference Room", TotalQuantity = 3 }
            );
        }
    }
}
