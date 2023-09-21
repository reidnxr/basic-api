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

            CreateMap<Models.Region, Models.DTO.UpdateMethod.Region>()
                .ReverseMap();

            CreateMap<Models.DTO.Region, Models.Region>()
                .ReverseMap();

            CreateMap<Models.DTO.UpdateMethod.Region, Models.Region>()
                .ReverseMap();

            CreateMap<Models.DTO.UpdateMethod.Region, Models.DTO.Region>()
                .ReverseMap();
        }
    }
}
