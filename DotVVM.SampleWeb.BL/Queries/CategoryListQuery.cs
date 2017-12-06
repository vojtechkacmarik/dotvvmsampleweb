using System.Linq;
using AutoMapper.QueryableExtensions;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.BL.Queries
{
    public class CategoryListQuery : AppQueryBase<CategoryListDTO>
    {
        public CategoryListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<CategoryListDTO> GetQueryable()
        {
            return Context.Categories
                .ProjectTo<CategoryListDTO>();
        }
    }
}