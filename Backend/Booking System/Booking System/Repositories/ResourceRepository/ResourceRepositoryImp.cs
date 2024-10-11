using Booking_System.Data;
using Booking_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Repositories.ResourceRepository
{
    public class ResourceRepositoryImp : IResourceRepository
    {
        private readonly BookingSystemContext _context;

        public ResourceRepositoryImp(BookingSystemContext bookingSystemContext) {
            _context = bookingSystemContext;
        }

        public async Task<Resource> AddResourceAsync(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();
            return resource;
        }

        public async Task DeleteResourceAsync(int id)
        {
            Resource resource = await GetResourceAsync(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<Resource> GetResourceAsync(int id)
        {
            return await _context.Resources.FindAsync(id);
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();
        }
    }
}
