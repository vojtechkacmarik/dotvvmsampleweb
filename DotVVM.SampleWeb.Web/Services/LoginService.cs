using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.SampleWeb.BL;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DotVVM.SampleWeb.Web.Services
{
    public class LoginService
    {
        private UserManager<AppUser> userManager;

        public LoginService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TryGetIdentity(LoginDTO loginData)
        {
            var user = await userManager.FindByNameAsync(loginData.UserName);
            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, loginData.Password))
                {
                    return new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    },
                        AuthenticationConstants.AUTHENTICATION_TYPE_NAME));
                }
            }
            return null;
        }
    }
}