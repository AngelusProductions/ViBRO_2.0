using AutoMapper;
using Vibro.API.Models;
using Vibro.API.Models.DTO;

namespace Vibro.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Vibe, VibeDto>().ReverseMap();
            CreateMap<Vibe, AddVibeRequestDto>().ReverseMap();
            CreateMap<Vibe, UpdateVibeRequestDto>().ReverseMap();
            CreateMap<Mix, MixDto>().ReverseMap();
            CreateMap<Mix, AddMixRequestDto>().ReverseMap();
            CreateMap<Mix, UpdateMixRequestDto>().ReverseMap();
        }
    }
}
