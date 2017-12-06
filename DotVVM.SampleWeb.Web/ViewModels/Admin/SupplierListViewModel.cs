using DotVVM.Framework.Controls;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using DotVVM.SampleWeb.Web.ViewModels.Admin.Base;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class SupplierListViewModel : ListPageViewModel<SupplierListDTO, int>
    {
        public SupplierListViewModel(AdminSuppliersFacade facade) : base(facade)
        {
        }

        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(SupplierListDTO.CompanyName)
        };

        public override string HighlightedMenuPath => "Suppliers";

        public override string PageTitle => "Suppliers";
    }
}