using AutoMapper;
using Booking_System.DTO;
using Booking_System.Model;
using Booking_System.Repositories.BookingRepository;
using Booking_System.Repositories.ResourceRepository;

namespace Booking_System.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository,IResourceRepository resourceRepository, IMapper mapper) {
            _bookingRepository = bookingRepository;
            _resourceRepository= resourceRepository;
            _mapper = mapper;
        }
        public async Task<Booking> CreateBookingAsync(BookingRequestDTO bookingRequest)
        {
            var (isAvailable, message) = await IsBookingAvailableAsync(bookingRequest);
            if (!isAvailable)
            {
                throw new InvalidOperationException(message);
            }
            Booking booking = _mapper.Map<Booking>(bookingRequest);
            Booking createdBooking = await _bookingRepository.AddBookingAsync(booking);
            if (createdBooking != null)
            {
                SendEmail(createdBooking.Id);
            }
            return createdBooking;
        }
        public async Task<(bool IsAvailable, string Message)> IsBookingAvailableAsync(BookingRequestDTO bookingRequest)
        {
            DateTime parsedStartDate = DateTime.Parse(bookingRequest.StartDate);
            DateTime parsedEndDate = DateTime.Parse(bookingRequest.EndDate);
            IEnumerable<Booking> bookings = await _bookingRepository.GetBookingsByResourceAndDateRangeAsync(bookingRequest.ResourceId, parsedStartDate, parsedEndDate);
            Console.WriteLine($"Number of bookings found: {bookings.Count()}");

            Console.WriteLine($"Number of bookings found: {bookings.Count()}");

            if (bookings.Any())
            {
                foreach (var booking in bookings)
                {
                    if ((parsedStartDate < booking.EndTime && parsedEndDate > booking.StartTime) ||
                        (parsedStartDate == booking.StartTime || parsedEndDate == booking.EndTime))
                    {
                        string message = $"Booking time conflicts with existing booking ID {booking.Id}.";
                        Console.WriteLine(message);
                        return (false, message); 
                    }
                }
            }

            int totalBookedQuantity = bookings.Sum(booking => booking.Quantity);
            Resource resource = await _resourceRepository.GetResourceAsync(bookingRequest.ResourceId);

            if (resource != null && (resource.TotalQuantity - totalBookedQuantity) < bookingRequest.Quantity)
            {
                string message = $"Requested quantity {bookingRequest.Quantity} exceeds available quantity.";
                Console.WriteLine(message);
                return (false, message); 
            }

            return (true, "Booking can proceed."); 
        }
        private void SendEmail(int bookingId)
        {
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {bookingId}");
        }
    }

    }
