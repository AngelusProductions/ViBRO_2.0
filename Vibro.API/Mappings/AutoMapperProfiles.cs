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
            CreateMap<AddVibeRequestDto, Vibe>().ReverseMap();
            CreateMap<UpdateVibeRequestDto, Vibe>().ReverseMap();
        }
    }
}
