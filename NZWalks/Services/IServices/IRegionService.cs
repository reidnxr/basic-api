using NZWalks.Models;
using System.Collections;

namespace NZWalks.Services.IServices
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetRegionAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
    }
}
