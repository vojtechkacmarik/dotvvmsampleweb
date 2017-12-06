using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin.Base;
using DotVVM.SampleWeb.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;
using DotVVM.SampleWeb.BL.Queries;

namespace DotVVM.SampleWeb.BL.Facades.Admin
{
    public class AdminSuppliersFacade
        : AppCrudFacadeBase<Suppliers, int, SupplierListDTO, SupplierDetailDTO>
    {
        public AdminSuppliersFacade(Func<SupplierListQuery> queryFactory, IRepository<Suppliers, int> repository, IEntityDTOMapper<Suppliers, SupplierDetailDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }
    }
}
