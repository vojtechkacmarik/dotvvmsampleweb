using System;
using System.Collections.Generic;
using System.Text;
using DotVVM.SampleWeb.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace DotVVM.SampleWeb.BL.Queries
{
    public abstract class AppQueryBase<TResult> : EntityFrameworkQuery<TResult, AppDbContext>
    {
        public AppQueryBase(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }
    }
}
