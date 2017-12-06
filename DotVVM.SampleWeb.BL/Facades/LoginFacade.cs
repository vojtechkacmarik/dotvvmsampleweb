using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.BL.Facades
{
    public class LoginFacade : FacadeBase
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginFacade(UserManager<AppUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<ClaimsPrincipal> SignIn(LoginDTO loginData)
        {
            var user = await _userManager.FindByNameAsync(loginData.UserName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, loginData.Password))
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