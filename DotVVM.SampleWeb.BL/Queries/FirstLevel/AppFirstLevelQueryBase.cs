using System;
using System.Collections.Generic;
using System.Text;
using DotVVM.SampleWeb.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace DotVVM.SampleWeb.BL.Queries.FirstLevel
{
    public class AppFirstLevelQueryBase<TResult> : EntityFrameworkFirstLevelQueryBase<TResult, AppDbContext> where TResult : class
    {
        public AppFirstLevelQueryBase(IEntityFrameworkUnitOfWorkProvider<AppDbContext> unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        public AppFirstLevelQueryBase(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }
    }
}
