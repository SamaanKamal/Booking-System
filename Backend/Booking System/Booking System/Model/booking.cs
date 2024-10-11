using System.ComponentModel.DataAnnotations;

namespace Booking_System.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int ResouceId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Resource Resource { get; set; }

    }
}
