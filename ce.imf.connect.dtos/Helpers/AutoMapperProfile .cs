using AutoMapper;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<LeadDto, Lead>().ReverseMap();

            //CreateMap<Lead, LeadDto>();
        }
    }
}
