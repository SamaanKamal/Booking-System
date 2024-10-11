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
            if(!await IsBookingAvailableAsync(bookingRequest))
            {
                throw new InvalidOperationException("Resource is not available for the requested period and quantity.");
            }
            Booking booking = _mapper.Map<Booking>(bookingRequest);
            Booking createdBooking = await _bookingRepository.AddBookingAsync(booking);
            if (createdBooking != null)
            {
                SendEmail(createdBooking.Id);
            }
            return createdBooking;
        }
        public async Task<bool> IsBookingAvailableAsync(BookingRequestDTO bookingRequest)
        {
            DateTime parsedStartDate = DateTime.Parse(bookingRequest.StartDate);
            DateTime parsedEndDate = DateTime.Parse(bookingRequest.EndDate);
            IEnumerable<Booking> bookings = await _bookingRepository.GetBookingsByResourceAndDateRangeAsync(bookingRequest.ResourceId, parsedStartDate, parsedEndDate);
            int totalBookedQuantity = bookings.Sum(booking => booking.Quantity);
            Resource resource = await _resourceRepository.GetResourceAsync(bookingRequest.ResourceId);
            return resource != null && (resource.TotalQuantity - totalBookedQuantity) >= bookingRequest.Quantity;
        }
        private void SendEmail(int bookingId)
        {
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {bookingId}");
        }
    }

    }
