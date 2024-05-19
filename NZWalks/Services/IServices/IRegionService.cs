using NZWalks.Models;
using System.Collections;

namespace NZWalks.Services.IServices
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAll();
        Task<Region> Get(Guid id);
        Task<Region> Add(Region region);
        Task<Region> DeleteRegion(Guid id);
        Task<Region> UpdateRegion(Region region, Guid id);
    }
}
