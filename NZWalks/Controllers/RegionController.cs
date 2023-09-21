using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NZWalks.Models;
using NZWalks.Services.IServices;
using System.Linq.Expressions;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly IRegionService regionService;
        private readonly IMapper mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
        {
            this.regionService = regionService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionService.GetAllAsync();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("GetRegion/{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            var region = await regionService.GetRegionAsync(id);

            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }
        [HttpPost]
        [Route("AddRegion")]
        public async Task<IActionResult> AddRegion(Models.DTO.AddMethod.Region region)
        {
            var newRegion = new Models.Region()
            {
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Population = region.Population,
                Long = region.Long,
                Name = region.Name,
            };
            newRegion = await regionService.AddRegionAsync(newRegion);
            var regionDTO = mapper.Map<Models.DTO.Region>(newRegion);
            return CreatedAtAction(nameof(GetRegion), regionDTO);
        }
        [HttpDelete]
        [Route("DeleteRegion")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            Region region = await regionService.DeleteRegion(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPatch]
        [Route("UpdateRegion/{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.Region region)
        {
            var updatedRegion = mapper.Map<Region>(region);

            
            if (regionService.UpdateRegion(updatedRegion, id) == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Models.DTO.Region>(region));
        }
    }
}
