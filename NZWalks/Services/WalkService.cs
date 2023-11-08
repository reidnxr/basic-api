using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.DataContext;
using NZWalks.Models;
using NZWalks.Services.IServices;

namespace NZWalks.Services
{
    public class WalkService : IWalkService
    {
        private readonly NZWalksDbContext dbContext;

        public WalkService(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> Add(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await dbContext.Walks.AddAsync(walk);
            dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> Get(Guid id)
        {
            return await dbContext.Walks.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Walk>> GetAll()
        {
            return await dbContext.Walks.ToListAsync();
        }
    }
}
