using AutoMapper;

namespace DotVVM.SampleWeb.BL.Mappings
{
    public interface IMapping
    {
        void ConfigureMaps(IMapperConfigurationExpression mapper);
    }
}