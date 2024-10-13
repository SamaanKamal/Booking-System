using Booking_System.DTO;
using Booking_System.Model;
using Booking_System.Services.BookingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_System.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> BookResource([FromBody] BookingRequestDTO bookingDto)
        {
            if (bookingDto == null||bookingDto.StartDate==null||bookingDto.EndDate==null||bookingDto.Quantity==null)
            {
                return BadRequest(new { Message = "Booking request cannot be null." });
            }
            try
            {
                Booking bookingResponse = await _bookingService.CreateBookingAsync(bookingDto);
                return Ok(new { Message = "Booking created successfully.", BookingId = bookingResponse.Id });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred.", Details = ex.Message });
            }
        }
    }
}
