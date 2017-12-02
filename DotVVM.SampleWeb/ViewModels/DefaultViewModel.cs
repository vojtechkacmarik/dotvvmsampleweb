using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.SampleWeb.DTO;
using DotVVM.SampleWeb.Services;

namespace DotVVM.SampleWeb.ViewModels
{
    public class DefaultViewModel : SiteViewModel
    {
        private ForumService forumService;

        public DefaultViewModel(ForumService forumService)
        {
            this.forumService = forumService;
        }

        public GridViewDataSet<ForumThreadDTO> ForumThreads { get; set; } = new GridViewDataSet<ForumThreadDTO>()
        {
            PageSize = 20
        };

        public ForumThreadCreateDTO NewThread { get; set; } = new ForumThreadCreateDTO();

        public override Task PreRender()
        {
            forumService.LoadForumThreads(ForumThreads);

            return base.PreRender();
        }

        [Authorize]
        public void CreateThread()
        {
            forumService.CreateThread(NewThread, GetUserId().Value);
            Context.RedirectToRoute(Context.Route.RouteName);
        }
    }
}