using DotVVM.Framework.Runtime.Filters;
using DotVVM.SampleWeb.BL;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    [Authorize(AuthenticationSchemes = AuthenticationConstants.AUTHENTICATION_TYPE_NAME)]
    public abstract class AdminViewModel : LayoutViewModel
    {
        public abstract string HighlightedMenuPath { get; }

        [Authorize(Roles = "Admin")]
        public void DeleteUser(int id)
        {
            // Only the users with the Admin role will be able
            // to call this method from the command binding.
        }

        // Please note that if you call the DeleteUser from your own code, the Authorize attribute will not be checked.
    }
}