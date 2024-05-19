using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NZWalks.Models;
using NZWalks.Services.IServices;
using System.Net;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly IRegionService regionService;
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
        {
            this.regionService = regionService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionService.GetAll();

            List<Models.DTO.Region> regionsDTO = _mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            Region region = await regionService.Get(id);

            if (region == null)
            {
                return NotFound();
            }
            Models.DTO.Region regionDTO = _mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Models.DTO.AddMethod.Region region)
        {
            Region target = _mapper.Map<Region>(region);
            target = await regionService.Add(target);

            Models.DTO.Region regionDTO = _mapper.Map<Models.DTO.Region>(target);
            return CreatedAtAction(nameof(Add), regionDTO);
        }
        
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Region region = await regionService.DeleteRegion(id);
            if (region == null)
            {
                return NotFound();
            }

            Models.DTO.Region regionDTO = _mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.Region region)
        {
            Region target = _mapper.Map<Region>(region);
            target = await regionService.UpdateRegion(target, id);
            if (target == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Models.DTO.Region>(region));
        }

    }
}
