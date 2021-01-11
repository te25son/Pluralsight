using AutoMapper;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data.Profiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<Speaker, SpeakerModel>();
        }
    }
}
