using System.Linq;
using AutoMapper.QueryableExtensions;
using DotVVM.SampleWeb.BL.DTO;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.BL.Queries
{
    public class RegionListQuery : AppQueryBase<RegionDTO>
    {
        public RegionListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<RegionDTO> GetQueryable()
        {
            return Context.Region
                .ProjectTo<RegionDTO>();
        }
    }
}