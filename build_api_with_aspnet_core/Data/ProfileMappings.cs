using AutoMapper;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(
                    destinationMember: c => c.Venue,
                    memberOptions: o => o.MapFrom(m => m.Location.VenueName)
                )
                .ReverseMap();
            CreateMap<Talk, TalkModel>()
                .ReverseMap();
            CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
        }
    }
}
