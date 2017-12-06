using System;
using AutoMapper;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL.Entities;

namespace DotVVM.SampleWeb.BL.Mappings
{
    public class RegionMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Region, RegionDTO>();
            mapper.CreateMap<RegionDTO, Region>()
                .ForMember(r => r.Id, m => m.Ignore())
                .ForMember(r => r.Territories, m => m.Ignore());
        }
    }
}
