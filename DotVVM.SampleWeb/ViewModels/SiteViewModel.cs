using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;

namespace DotVVM.SampleWeb.ViewModels
{
    public class SiteViewModel : DotvvmViewModelBase
    {
        public async Task Logout()
        {
            await Context.GetAuthentication().SignOutAsync(Startup.AUTHENTICATION_SCHEME);
            Context.RedirectToRoute("Default");
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