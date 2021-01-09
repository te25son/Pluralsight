using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
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
