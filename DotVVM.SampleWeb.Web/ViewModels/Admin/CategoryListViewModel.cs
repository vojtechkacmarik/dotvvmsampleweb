using DotVVM.Framework.Controls;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;
using DotVVM.SampleWeb.Web.ViewModels.Admin.Base;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class CategoryListViewModel : ListPageViewModel<CategoryListDTO, int>
    {
        public CategoryListViewModel(AdminCategoriesFacade facade) : base(facade)
        {
        }

        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(CategoryListDTO.CategoryName)
        };

        public override string PageTitle => "Categories";

        public override string HighlightedMenuPath => "Categories";
    }
}