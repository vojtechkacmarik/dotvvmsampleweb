using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using DotVVM.SampleWeb.Web.ViewModels.Admin.Base;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class SupplierDetailViewModel : DetailPageViewModel<SupplierDetailDTO, int>
    {
        public SupplierDetailViewModel(AdminSuppliersFacade facade) : base(facade)
        {
        }

        public override string ListPageRouteName => "Admin_SupplierList";

        public override string HighlightedMenuPath => "Suppliers";

        public override string PageTitle => IsNew ? "New Supplier" : "Edit Supplier";
    }
}