using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using DotVVM.SampleWeb.BL;

namespace DotVVM.SampleWeb.Web.ViewModels
{
    public class SiteViewModel : DotvvmViewModelBase
    {
        public async Task Logout()
        {
            await Context.GetAuthentication().SignOutAsync(AuthenticationConstants.AUTHENTICATION_TYPE_NAME);
            Context.RedirectToRoute(Routes.ROUTE_NAME_DEFAULT);
        }

        protected int? GetUserId()
        {
            if (Context.HttpContext.User.Identity.IsAuthenticated)
            {
                return int.Parse(Context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            else
            {
                return null;
            }
        }
    }
}