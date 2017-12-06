using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.BL.Facades.Admin;

namespace DotVVM.SampleWeb.Web.ViewModels.Admin
{
    public class RegionListViewModel : AdminViewModel
    {
        private readonly AdminRegionsFacade pageFacade;

        public RegionListViewModel(AdminRegionsFacade pageFacade)
        {
            this.pageFacade = pageFacade;

            Regions = new GridViewDataSet<RegionDTO>()
            {
                PagingOptions =
                {
                    PageSize = 50
                },
                SortingOptions =
                {
                    SortExpression = nameof(RegionDTO.Id)
                }
            };
        }

        public override string PageTitle => "Regions";

        public override string HighlightedMenuPath => "Regions";

        public GridViewDataSet<RegionDTO> Regions { get; set; }

        public override Task PreRender()
        {
            pageFacade.FillDataSet(Regions);

            return base.PreRender();
        }

        public void Delete(int id)
        {
            pageFacade.Delete(id);
        }
    }
}