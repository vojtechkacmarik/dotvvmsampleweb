using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.DynamicData;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using DotVVM.SampleWeb.Web.Controls;
using DotVVM.SampleWeb.Web.Filters;
using DotVVM.SampleWeb.Web.Presenters;

namespace DotVVM.SampleWeb.Web
{
    public class DotvvmStartup : IDotvvmStartup
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBusinessPackConfiguration();
            config.AddDynamicDataConfiguration();

            config.Runtime.GlobalFilters.Add(new ErrorHandlingFilter());

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/default.dothtml");
            config.RouteTable.Add(Routes.ROUTE_NAME_DEFAULT2, "default2", "Views/default2.dothtml");
            config.RouteTable.Add(Routes.ROUTE_NAME_DEFAULT3, "Default3", "Views/Default3.dothtml");
            config.RouteTable.Add("Login", "login", "Views/login.dothtml");
            config.RouteTable.Add("Thread", "thread/{Id}", "Views/thread.dothtml");
            config.RouteTable.Add("OrderDetail", "order/{id?}", "Views/OrderDetail.dothtml");

            // category image presenter
            config.RouteTable.Add("CategoryImage", "image/category/{Id}", null, null, Startup.Resolve<CategoryImagePresenter>);

            // Uncomment the following line to auto-register all dothtml files in the Views folder
            // config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));

            // auto-discovery strategy for admin section
            config.RouteTable.AutoDiscoverRoutes(new AdminRouteStrategy(config));
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddMarkupControl("cc", "SaveCancelButtons", "Controls/SaveCancelButtons.dotcontrol");
            config.Markup.AddMarkupControl("cc", "ProductListOrderDialog", "Controls/ProductListOrderDialog.dotcontrol");
            config.Markup.AddMarkupControl("cc", "NewItemButton", "Controls/NewItemButton.dotcontrol");

            config.Markup.AddCodeControls("cc", typeof(TextBoxFormField));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("site", new StylesheetResource(new FileResourceLocation("~/Style/css/all.css")));
        }
    }
}