using System;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.SampleWeb.BL;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades;

namespace DotVVM.SampleWeb.Web.ViewModels
{
    public class Default3ViewModel : LayoutViewModel
    {
        private readonly LoginFacade _loginFacade;

        public Default3ViewModel(LoginFacade loginFacade)
        {
            _loginFacade = loginFacade ?? throw new ArgumentNullException(nameof(loginFacade));
        }

        public override string PageTitle => "Sign In";

        public LoginDTO Login { get; set; } = new LoginDTO();

        public async Task SignIn()
        {
            var principal = await _loginFacade.SignIn(Login);
            if (principal == null)
            {
                AlertText = "The credentials are not valid!";
                AlertType = AlertType.Danger;
                return;
            }

            await Context.GetAuthentication().SignInAsync(AuthenticationConstants.AUTHENTICATION_TYPE_NAME, principal);
            Context.RedirectToRoute("Admin_RegionList");
        }
    }
}