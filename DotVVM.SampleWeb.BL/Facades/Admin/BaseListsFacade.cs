using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Queries;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.BL.Facades.Admin
{
    public class BaseListsFacade : FacadeBase
    {

        public Func<CategoryBasicListQuery> CategoryBasicListQuery { get; set; }

        public Func<SupplierBasicListQuery> SupplierBasicListQuery { get; set; }



        public List<CategoryBasicDTO> GetCategories()
        {
            using (UnitOfWorkProvider.Create())
            {
                return CategoryBasicListQuery().Execute().ToList();
            }
        }

        public List<SupplierBasicDTO> GetSuppliers()
        {
            using (UnitOfWorkProvider.Create())
            {
                return SupplierBasicListQuery().Execute().ToList();
            }
        }

    }
}
