using AutoMapper;

namespace Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Models.WalkDifficulty, Models.DTO.UpdateMethod.WalkDifficulty>()
                .ReverseMap();
            CreateMap<Models.DTO.WalkDifficulty, Models.DTO.UpdateMethod.WalkDifficulty>()
                .ReverseMap();
            CreateMap<Models.WalkDifficulty, Models.DTO.AddMethod.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
