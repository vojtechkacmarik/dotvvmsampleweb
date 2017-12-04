using System;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.SampleWeb.Dto;
using DotVVM.SampleWeb.Services;

namespace DotVVM.SampleWeb.ViewModels
{
    public class DefaultViewModel : SiteViewModel
    {
        private readonly OrderService _orderService;
        private readonly ForumService _forumService;

        public DefaultViewModel(ForumService forumService, OrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        }

        public GridViewDataSet<ForumThreadDTO> ForumThreads { get; set; } = new GridViewDataSet<ForumThreadDTO>()
        {
            PagingOptions =
            {
                PageSize = 20
            },
        };

        public ForumThreadCreateDTO NewThread { get; set; } = new ForumThreadCreateDTO();

        public override Task PreRender()
        {
            _forumService.LoadForumThreads(ForumThreads);
            var orders = _orderService.GetOrdersQuery();
            Orders.LoadFromQueryable(orders);

            return base.PreRender();
        }

        [Authorize]
        public void CreateThread()
        {
            _forumService.CreateThread(NewThread, GetUserId().Value);
            Context.RedirectToRoute(Context.Route.RouteName);
        }

        public GridViewDataSet<OrderListDTO> Orders { get; set; } = new GridViewDataSet<OrderListDTO>
        {
            PagingOptions =
            {
                PageSize = 10
            },
            SortingOptions =
            {
                SortExpression = "CreatedDate",
                SortDescending = true
            }
        };
    }
}