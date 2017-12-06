using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DotVVM.SampleWeb.BL;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.Web.Installers
{
    public class FacadeInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn<FacadeBase>()
                    .LifestyleTransient()

            );
        }
    }
}