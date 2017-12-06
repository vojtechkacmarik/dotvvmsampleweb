using System;
using System.Collections.Generic;
using System.Text;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin.Base;
using DotVVM.SampleWeb.BL.Queries;
using DotVVM.SampleWeb.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.BL.Facades.Admin
{
    public class AdminRegionsFacade : AppCrudFacadeBase<Region, int, RegionDTO, RegionDTO>
    {
        public AdminRegionsFacade(Func<RegionListQuery> queryFactory, IRepository<Region, int> repository, IEntityDTOMapper<Region, RegionDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }

    }
}
