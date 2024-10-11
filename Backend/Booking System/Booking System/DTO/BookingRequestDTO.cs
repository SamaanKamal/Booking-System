namespace Booking_System.DTO
{
    public class BookingRequestDTO
    {
        public int ResourceId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Quantity { get; set; }
    }
}
