using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotVVM.SampleWeb.Web.Controls
{
    public class NewItemButton : DotvvmMarkupControl
    {
        [MarkupOptions(AllowBinding = false, Required = true)]
        public string RouteName
        {
            get { return (string)GetValue(RouteNameProperty); }
            set { SetValue(RouteNameProperty, value); }
        }

        public static readonly DotvvmProperty RouteNameProperty
            = DotvvmProperty.Register<string, NewItemButton>(c => c.RouteName, null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DotvvmProperty TextProperty
            = DotvvmProperty.Register<string, NewItemButton>(c => c.Text, null);
    }
}