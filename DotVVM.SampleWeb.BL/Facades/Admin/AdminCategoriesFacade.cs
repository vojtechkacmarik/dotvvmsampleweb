using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin.Base;
using DotVVM.SampleWeb.BL.Queries;
using DotVVM.SampleWeb.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.BL.Facades.Admin
{
    public class AdminCategoriesFacade : AppCrudFacadeBase<Categories, int, CategoryListDTO, CategoryDetailDTO>
    {
        public AdminCategoriesFacade(Func<CategoryListQuery> queryFactory, IRepository<Categories, int> repository, IEntityDTOMapper<Categories, CategoryDetailDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }


        public byte[] GetImage(int categoryId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var category = Repository.GetById(categoryId);
                return category.Picture;
            }
        }

        public void SaveImage(int categoryId, Stream stream)
        {
            var buffer = new byte[stream.Length + 78];
            stream.Read(buffer, 78, buffer.Length - 78);         // 78 bytes OLE header

            using (var uow = UnitOfWorkProvider.Create())
            {
                var category = Repository.GetById(categoryId);
                category.Picture = buffer;
                uow.Commit();
            }
        }
    }
}
