using AutoMapper;
using Models;

namespace Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, Models.DTO.Region>()
                .ReverseMap();

            CreateMap<Region, Models.DTO.UpdateMethod.Region>()
                .ReverseMap();

            CreateMap<Models.DTO.Region, Region>()
                .ReverseMap();

            CreateMap<Models.DTO.UpdateMethod.Region, Region>()
                .ReverseMap();

            CreateMap<Models.DTO.UpdateMethod.Region, Models.DTO.Region>()
                .ReverseMap();
        }
    }
}
