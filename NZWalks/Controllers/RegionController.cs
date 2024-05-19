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

            bool valid = IsValid(region);
            if (!valid)
            {
                return BadRequest(ModelState);
            }

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
            bool valid = IsValid(region);

            if (!valid)
            {
                return BadRequest(ModelState);   
            }

            Region target = _mapper.Map<Region>(region);
            target = await regionService.UpdateRegion(target, id);
            if (target == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Models.DTO.Region>(region));
        }

        #region Private Methods

        private bool IsValid(Models.DTO.AddMethod.Region region)
        {
            bool valid = true;

            if(region == null)
            {
                ModelState.AddModelError(nameof(region), $"Region cannot be null.");
                valid = false;
                return valid;
            }

            if (string.IsNullOrWhiteSpace(region.Code))
            {
                ModelState.AddModelError(nameof(region.Code), $"{nameof(region.Code)} cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(region.Name))
            {
                ModelState.AddModelError(nameof(region.Name), $"{nameof(region.Name)} cannot be null or empty or white space.");
            }

            if (region.Area <= 0)
            {
                ModelState.AddModelError(nameof(region.Area), $"{nameof(region.Area)} cannot be less than or equal to 0.");
            }

            if (region.Lat <= 0)
            {
                ModelState.AddModelError(nameof(region.Lat), $"{nameof(region.Lat)} cannot be less than or equal to 0.");
            }

            if (region.Long <= 0)
            {
                ModelState.AddModelError(nameof(region.Long), $"{nameof(region.Long)} cannot be less than or equal to 0.");
            }

            if (region.Population < 0)
            {
                ModelState.AddModelError(nameof(region.Population), $"{nameof(region.Population)} cannot be less than to 0.");
            }

            if(ModelState.ErrorCount > 0)
            {
                valid = false;
            }

            return valid;
        }
        private bool IsValid(Models.DTO.UpdateMethod.Region region)
        {
            bool valid = true;

            if (region == null)
            {
                ModelState.AddModelError(nameof(region), $"Region cannot be null.");
                valid = false;
                return valid;
            }

            if (string.IsNullOrWhiteSpace(region.Code))
            {
                ModelState.AddModelError(nameof(region.Code), $"{nameof(region.Code)} cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(region.Name))
            {
                ModelState.AddModelError(nameof(region.Name), $"{nameof(region.Name)} cannot be null or empty or white space.");
            }

            if (region.Area <= 0)
            {
                ModelState.AddModelError(nameof(region.Area), $"{nameof(region.Area)} cannot be less than or equal to 0.");
            }

            if (region.Lat <= 0)
            {
                ModelState.AddModelError(nameof(region.Lat), $"{nameof(region.Lat)} cannot be less than or equal to 0.");
            }

            if (region.Long <= 0)
            {
                ModelState.AddModelError(nameof(region.Long), $"{nameof(region.Long)} cannot be less than or equal to 0.");
            }

            if (region.Population < 0)
            {
                ModelState.AddModelError(nameof(region.Population), $"{nameof(region.Population)} cannot be less than to 0.");
            }

            if (ModelState.ErrorCount > 0)
            {
                valid = false;
            }

            return valid;
        }

        #endregion
    }
}
