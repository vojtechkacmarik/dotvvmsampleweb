using System.Collections.Generic;
using DotVVM.Framework.ViewModel;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using DotVVM.SampleWeb.Web.ViewModels.Admin.Base;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class ProductDetailViewModel : DetailPageViewModel<ProductDetailDTO, int>
    {
        private readonly BaseListsFacade baseListsFacade;

        public ProductDetailViewModel(AdminProductsFacade facade, BaseListsFacade baseListsFacade) : base(facade)
        {
            this.baseListsFacade = baseListsFacade;
        }

        public override string PageTitle => IsNew ? "New Product" : "Edit Product";
        public override string HighlightedMenuPath => "Products";
        public override string ListPageRouteName => "Admin_ProductList";

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryBasicDTO> Categories => baseListsFacade.GetCategories();

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<SupplierBasicDTO> Suppliers => baseListsFacade.GetSuppliers();
    }
}