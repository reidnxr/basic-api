using NZWalks.Models;
using System.Collections;

namespace NZWalks.Services.IServices
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetRegionAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
        Task<Region> DeleteRegion(Guid id);
        Task<Region> UpdateRegion(Region region, Guid id);
    }
}
