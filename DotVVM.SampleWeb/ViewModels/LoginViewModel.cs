using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.SampleWeb.Dto;
using DotVVM.SampleWeb.Services;

namespace DotVVM.SampleWeb.ViewModels
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
                await Context.GetAuthentication().SignInAsync(Startup.AUTHENTICATION_SCHEME, principal);
                Context.RedirectToRoute("Default");
            }
            else
            {
                ErrorMessage = "Invalid credentials.";
            }
        }
    }
}