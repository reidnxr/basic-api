using Microsoft.EntityFrameworkCore;
using NZWalks.DataContext;
using NZWalks.Models;
using NZWalks.Services.IServices;
using System.Collections;

namespace NZWalks.Services
{
    public class RegionService : IRegionService
    {
        private readonly NZWalksDbContext dbContext;

        public RegionService(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Models.Region> AddRegionAsync(Models.Region region)
        {
            region.id = Guid.NewGuid();
            await dbContext.AddAsync(region);
            dbContext.SaveChanges();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await dbContext.Regions.Where(item => item.id == id).FirstOrDefaultAsync();
        }
    }
}
