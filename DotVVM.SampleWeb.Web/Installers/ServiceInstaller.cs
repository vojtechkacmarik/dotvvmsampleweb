using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DotVVM.SampleWeb.DAL;
using DotVVM.SampleWeb.Web.Services;

namespace DotVVM.SampleWeb.Web.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For(typeof(AppDbInitializer))
                    .ImplementedBy(typeof(AppDbInitializer))
                    .LifestyleTransient(),

                Component.For(typeof(LoginService))
                    .ImplementedBy(typeof(LoginService))
                    .LifestyleTransient(),

                Component.For(typeof(ForumService))
                    .ImplementedBy(typeof(ForumService))
                    .LifestyleTransient(),

                Component.For(typeof(OrderService))
                    .ImplementedBy(typeof(OrderService))
                    .LifestyleTransient(),

                Component.For(typeof(ProductService))
                    .ImplementedBy(typeof(ProductService))
                    .LifestyleTransient()
            );
        }
    }
}