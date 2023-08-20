using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionService.GetAllAsync();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
    }
}
