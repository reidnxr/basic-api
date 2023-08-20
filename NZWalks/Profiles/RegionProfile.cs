using AutoMapper;
using NZWalks.Models;
using NZWalks.Models.DTO;

namespace NZWalks.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Region, Models.DTO.Region>()
                .ReverseMap();
        }
    }
}
