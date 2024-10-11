using System.ComponentModel.DataAnnotations;

namespace Booking_System.Model
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalQuantity { get; set; }
    }
}
