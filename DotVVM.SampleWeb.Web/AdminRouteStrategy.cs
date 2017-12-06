using System;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;

namespace DotVVM.SampleWeb.Web
{
    public class AdminRouteStrategy : DefaultRouteStrategy
    {
        public AdminRouteStrategy(DotvvmConfiguration config)
            : base(config, "Views/Admin")
        {
        }

        protected override string GetRouteName(RouteStrategyMarkupFileInfo file)
        {
            return "Admin_" + file.ViewsFolderRelativePath.Replace("/", "_").Replace(".dothtml", "");
        }

        protected override string GetRouteUrl(RouteStrategyMarkupFileInfo file)
        {
            if (IsDetailPage(file))
            {
                return "admin/" + base.GetRouteUrl(file) + "/{Id?}";
            }
            return "admin/" + base.GetRouteUrl(file);
        }

        protected override object GetRouteDefaultParameters(RouteStrategyMarkupFileInfo file)
        {
            if (IsDetailPage(file))
            {
                return new { Id = 0 };
            }
            return base.GetRouteDefaultParameters(file);
        }

        private static bool IsDetailPage(RouteStrategyMarkupFileInfo file)
        {
            return file.AppRelativePath.EndsWith("Detail.dothtml", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}