using System;
using System.Security.Claims;
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

            // CookieAuthenticationDefaults.AuthenticationScheme
            await Context.GetAuthentication().SignInAsync(AuthenticationConstants.AUTHENTICATION_TYPE_NAME, principal);
            Context.RedirectToRoute("Admin_RegionList");
        }

        public async Task LoginTask()
        {
            if (VerifyCredentials(Login.UserName, Login.Password))
            {
                // the CreateIdentity is your own method which creates the IIdentity representing the user
                var identity = CreateIdentity(Login.UserName);
                await Context.GetAuthentication().SignInAsync(AuthenticationConstants.AUTHENTICATION_TYPE_NAME, new ClaimsPrincipal(identity));
                Context.RedirectToRoute("Default");
            }
        }

        private bool VerifyCredentials(string username, string password)
        {
            // verify credentials and return true or false
            return true;
        }

        private ClaimsIdentity CreateIdentity(string username)
        {
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, username),

                    // add claims for each user role
                    new Claim(ClaimTypes.Role, "administrator"),
                },
                AuthenticationConstants.AUTHENTICATION_TYPE_NAME);
            return identity;
        }
    }
}