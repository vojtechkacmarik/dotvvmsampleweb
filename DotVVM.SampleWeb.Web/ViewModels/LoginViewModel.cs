using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.SampleWeb.BL;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.Web.Services;

namespace DotVVM.SampleWeb.Web.ViewModels
{
    public class LoginViewModel : SiteViewModel
    {
        private LoginService loginService;

        public LoginViewModel(LoginService loginService)
        {
            this.loginService = loginService;
        }

        public LoginDTO LoginData { get; set; } = new LoginDTO();

        public string ErrorMessage { get; set; }

        public async Task Login()
        {
            ClaimsPrincipal principal = await loginService.TryGetIdentity(LoginData);
            if (principal != null)
            {
                await Context.GetAuthentication().SignInAsync(AuthenticationConstants.AUTHENTICATION_TYPE_NAME, principal);
                Context.RedirectToRoute(DotvvmRouteNames.ROUTE_NAME_DEFAULT);
            }
            else
            {
                ErrorMessage = "Invalid credentials.";
            }
        }
    }
}