using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using DotVVM.SampleWeb.BL;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.Web.ViewModels
{
    public abstract class LayoutViewModel : DotvvmViewModelBase
    {
        public abstract string PageTitle { get; }

        [Bind(Direction.ServerToClient)]
        public string AlertText { get; set; }

        [Bind(Direction.ServerToClient)]
        public AlertType AlertType { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
        public string CurrentUserName => Context.HttpContext.User.Identity.Name;

        public async Task SignOut()
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
            return null;
        }

        protected bool ExecuteSafe(Action action, string errorMessage = null)
        {
            try
            {
                action();
                return true;
            }
            catch (DotvvmInterruptRequestExecutionException)
            {
                // we must not catch DotvvmInterruptRequestExecutionException otherwise the redirects will break
                throw;
            }
            catch (UIException ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception)
            {
                if (errorMessage == null)
                {
                    errorMessage = "An unknown error occurred. Please try again or contact the support.";
                }
            }

            AlertText = errorMessage;
            AlertType = AlertType.Danger;

            return false;
        }
    }
}