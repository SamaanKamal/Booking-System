using AutoMapper;
using Booking_System.DTO;
using Booking_System.Model;
using Booking_System.Repositories.ResourceRepository;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Services.ResourceService
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public ResourceService(IResourceRepository resourceRepository,IMapper mapper) {
            _resourceRepository=resourceRepository;
            _mapper=mapper;
        }
        public async Task<Resource> AddResourceAsync(ResourceRequestDTO resourceRequest)
        {
            Resource resource =_mapper.Map<Resource>(resourceRequest);
            Resource CreatedResource = await _resourceRepository.AddResourceAsync(resource);
            return CreatedResource;
        }

        public async Task DeleteResourceAsync(int id)
        {
            await _resourceRepository.DeleteResourceAsync(id);
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourcesAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            return await _resourceRepository.GetResourceAsync(id);
        }

        public async Task UpdateResourceAsync(int id,ResourceRequestDTO resourceRequest)
        {
            if (id != resourceRequest.Id)
            {
                throw new ArgumentException("Resource ID mismatch.");
            }

            Resource existingResource = await _resourceRepository.GetResourceAsync(id);
            if (existingResource == null)
            {
                throw new KeyNotFoundException("Resource not found.");
            }

            // Update properties
            existingResource.Name = resourceRequest.Name;
            existingResource.TotalQuantity = resourceRequest.TotalQuantity;

            await _resourceRepository.UpdateResourceAsync(existingResource);
        }
    }
}
