using AutoMapper;
using NZWalks.Models;
using NZWalks.Models.DTO;

namespace NZWalks.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Walk, Models.DTO.Walk>()
                .ReverseMap();

            CreateMap<Models.Walk, Models.DTO.UpdateMethod.Walk>()
                .ReverseMap();
            CreateMap<Models.DTO.Walk, Models.DTO.UpdateMethod.Walk>()
                .ReverseMap();
        }
    }
}
