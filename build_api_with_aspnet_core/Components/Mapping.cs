using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Components
{
    public static class Mapping
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => ConfigureMappers(cfg));
            return config.CreateMapper();
        }

        private static void ConfigureMappers(IMapperConfigurationExpression config)
        {
            config.CreateMap<Camp, CampModel>()
                .ForMember(
                    destinationMember: c => c.Venue,
                    memberOptions: o => o.MapFrom(m => m.Location.VenueName))
                .ReverseMap();

            config.CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(
                    destinationMember: t => t.Camp,
                    memberOptions: o => o.Ignore())
                .ForMember(
                    destinationMember: t => t.Speaker,
                    memberOptions: o => o.Ignore()
                );

            config.CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
        }
    }
}
