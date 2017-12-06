using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class RegionDetailViewModel : AdminViewModel
    {
        private readonly AdminRegionsFacade pageFacade;

        public RegionDetailViewModel(AdminRegionsFacade pageFacade)
        {
            this.pageFacade = pageFacade;
        }

        public override string PageTitle => IsNew ? "New Region" : "Edit Region";

        public override string HighlightedMenuPath => "Regions";

        [FromRoute("Id")]
        public int CurrentItemId { get; private set; }

        public bool IsNew => CurrentItemId == 0;

        public RegionDTO CurrentItem { get; set; }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                if (CurrentItemId != 0)
                {
                    CurrentItem = pageFacade.GetDetail(CurrentItemId);
                }
                else
                {
                    CurrentItem = pageFacade.InitializeNew();
                }
            }

            return base.PreRender();
        }

        public void Save()
        {
            pageFacade.Save(CurrentItem);
            Context.RedirectToRoute("Admin_RegionList");
        }

        public void Cancel()
        {
            Context.RedirectToRoute("Admin_RegionList");
        }
    }
}