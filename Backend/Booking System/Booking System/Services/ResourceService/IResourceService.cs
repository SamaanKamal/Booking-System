using Booking_System.DTO;
using Booking_System.Model;

namespace Booking_System.Services.ResourceService
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(int id);
        Task<Resource> AddResourceAsync(ResourceRequestDTO resourceRequest);
        Task UpdateResourceAsync(int id,ResourceRequestDTO resourceRequest);
        Task DeleteResourceAsync(int id);
    }
}
