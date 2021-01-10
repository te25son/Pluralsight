using AutoMapper;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data.Profiles
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(
                    destinationMember: c => c.Venue,
                    memberOptions: o => o.MapFrom(m => m.Location.VenueName)
                );
        }
    }
}
