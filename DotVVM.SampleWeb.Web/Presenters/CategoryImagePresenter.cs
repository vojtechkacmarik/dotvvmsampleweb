using System;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.SampleWeb.BL.Facades.Admin;

namespace DotVVM.SampleWeb.Web.Presenters
{
    public class CategoryImagePresenter : IDotvvmPresenter
    {
        private readonly AdminCategoriesFacade facade;

        public CategoryImagePresenter(AdminCategoriesFacade facade)
        {
            this.facade = facade;
        }

        public Task ProcessRequest(IDotvvmRequestContext context)
        {
            var id = Convert.ToInt32(context.Parameters["Id"]);

            var bytes = facade.GetImage(id);

            context.HttpContext.Response.ContentType = "image/jpeg";
            context.HttpContext.Response.Body.Write(bytes, 78, bytes.Length - 78);      // cut off the OLE header

            return Task.CompletedTask;
        }
    }
}