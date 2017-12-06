using DotVVM.Framework.Runtime.Filters;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    [Authorize]
    public abstract class AdminViewModel : LayoutViewModel
    {
        public abstract string HighlightedMenuPath { get; }
    }
}