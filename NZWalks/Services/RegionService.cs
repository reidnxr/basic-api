using Microsoft.EntityFrameworkCore;
using NZWalks.DataContext;
using NZWalks.Models;
using NZWalks.Services.IServices;

namespace NZWalks.Services
{
    public class RegionService : IRegionService
    {
        private readonly NZWalksDbContext dbContext;

        public RegionService(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
