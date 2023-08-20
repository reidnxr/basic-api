using NZWalks.Models;

namespace NZWalks.Services.IServices
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
