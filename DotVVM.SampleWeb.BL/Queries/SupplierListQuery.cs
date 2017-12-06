using System.Linq;
using DotVVM.SampleWeb.BL.DTO;
using Riganti.Utils.Infrastructure.Core;
using AutoMapper.QueryableExtensions;

namespace DotVVM.SampleWeb.BL.Queries
{
    public class SupplierListQuery : AppQueryBase<SupplierListDTO>
    {
        public SupplierListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<SupplierListDTO> GetQueryable()
        {
            return Context.Suppliers
                .ProjectTo<SupplierListDTO>();
        }
    }
}