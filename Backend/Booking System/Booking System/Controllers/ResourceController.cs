using Booking_System.DTO;
using Booking_System.Model;
using Booking_System.Services.ResourceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_System.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService) {
            _resourceService=resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetAllResources()
        {
           IEnumerable<Resource> resources = await _resourceService.GetAllResourcesAsync();
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResourceById(int id)
        {
            Resource resource = await _resourceService.GetResourceByIdAsync(id);
            if (resource == null) {
                return NotFound(new { Message = "Resource not found." });
            }
            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult<Resource>> CreateResource([FromBody] ResourceRequestDTO resourceRequest)
        {
            if (resourceRequest == null)
            {
                return BadRequest(new { Message = "Resource request cannot be null." });
            }

            Resource createdResource = await _resourceService.AddResourceAsync(resourceRequest);
            return CreatedAtAction(nameof(GetResourceById), new { id = createdResource.Id }, createdResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResourceRequestDTO resourceRequest)
        {
            if (resourceRequest == null)
            {
                return BadRequest(new { Message = "Resource request cannot be null." });
            }

            try
            {
                await _resourceService.UpdateResourceAsync(id, resourceRequest);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Resource not found." });
            }
            catch (ArgumentException)
            {
                return BadRequest(new { Message = "Resource ID mismatch." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _resourceService.DeleteResourceAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Resource not found." });
            }
        }
    }
}
