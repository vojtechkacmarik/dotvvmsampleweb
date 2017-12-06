using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;

namespace DotVVM.SampleWeb.Web.Installers
{
    public class PresentationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Classes.FromAssemblyContaining<Startup>()
                    .BasedOn<IDotvvmPresenter>()
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<Startup>()
                    .BasedOn<DotvvmViewModelBase>()
                    .LifestyleTransient()

            );
        }
    }
}