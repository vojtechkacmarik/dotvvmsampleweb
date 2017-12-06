using System;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.Web.Services;

namespace DotVVM.SampleWeb.Web.ViewModels
{
    public class ThreadViewModel : SiteViewModel
    {
        private ForumService forumService;

        public ThreadViewModel(ForumService forumService)
        {
            this.forumService = forumService;
        }

        public GridViewDataSet<ForumPostDTO> ForumPosts { get; set; } = new GridViewDataSet<ForumPostDTO>()
        {
            PagingOptions =
            {
                PageSize = 10
            }
        };

        public ForumPostCreateDTO NewPost { get; set; } = new ForumPostCreateDTO();

        public override Task PreRender()
        {
            var forumThreadId = Convert.ToInt32(Context.Parameters["Id"]);
            forumService.LoadForumPosts(forumThreadId, ForumPosts);

            return base.PreRender();
        }

        [Authorize]
        public void AddPost()
        {
            var forumThreadId = Convert.ToInt32(Context.Parameters["Id"]);
            forumService.CreatePost(NewPost, forumThreadId, GetUserId().Value);
            Context.RedirectToRoute(Context.Route.RouteName);
        }
    }
}