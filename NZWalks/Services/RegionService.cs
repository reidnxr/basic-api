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
            await dbContext.Regions.AddAsync(region);
            dbContext.SaveChanges();
            return region;
        }

        public async Task<Region> DeleteRegion(Guid id)
        {
            Region region = await dbContext.Regions.Where(item => item.id == id).FirstOrDefaultAsync();
            if (region == null)
            {
                return null;
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
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

        public async Task<Region> UpdateRegion(Region region, Guid id)
        {
            var oldRegion = await dbContext.Regions.Where(item => item.id == id).FirstOrDefaultAsync();
            if (oldRegion == null)
            {
                return null;
            }

            oldRegion.Population = region.Population;
            oldRegion.Lat = region.Lat;
            oldRegion.Code = region.Code;
            oldRegion.Name = region.Name;
            oldRegion.Area = region.Area;
            oldRegion.Long = region.Long;

            dbContext.Regions.Update(oldRegion);
            await dbContext.SaveChangesAsync();
            return region;
        }
    }
}
