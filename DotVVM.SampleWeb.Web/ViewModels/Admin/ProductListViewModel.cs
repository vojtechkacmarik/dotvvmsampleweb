using System.Collections.Generic;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using DotVVM.SampleWeb.Web.ViewModels.Admin.Base;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class ProductListViewModel : FilteredListPageViewModel<ProductListDTO, int, ProductFilterDTO>
    {
        private readonly BaseListsFacade baseListsFacade;

        public ProductListViewModel(AdminProductsFacade facade, BaseListsFacade baseListsFacade, ProductListOrderDialog productListOrderDialog) : base(facade)
        {
            this.baseListsFacade = baseListsFacade;

            OrderDialog = productListOrderDialog;
        }

        public override string PageTitle => "Products";
        public override string HighlightedMenuPath => "Products";

        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(ProductListDTO.ProductName)
        };

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryBasicDTO> Categories => baseListsFacade.GetCategories();

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<SupplierBasicDTO> Suppliers => baseListsFacade.GetSuppliers();

        public ProductListOrderDialog OrderDialog { get; set; }

        public override Task Init()
        {
            OrderDialog.RefreshRequested += () =>
            {
                Items.RequestRefresh(true);
            };

            return base.Init();
        }
    }
}