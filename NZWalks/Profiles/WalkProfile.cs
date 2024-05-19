using AutoMapper;
using Models;

namespace Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Walk, Walk>()
                .ReverseMap();

            CreateMap<Models.Walk, Models.DTO.UpdateMethod.Walk>()
                .ReverseMap();
            CreateMap<Walk, Models.DTO.UpdateMethod.Walk>()
                .ReverseMap();
        }
    }
}
