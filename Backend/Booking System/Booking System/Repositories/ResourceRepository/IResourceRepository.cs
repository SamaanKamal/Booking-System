using Booking_System.Model;

namespace Booking_System.Repositories.ResourceRepository
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceAsync(int id);
        Task<Resource> AddResourceAsync(Resource resource);
        Task DeleteResourceAsync(int id);
        Task UpdateResourceAsync(Resource resource);
    }
}
