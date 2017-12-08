using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DotVVM.SampleWeb.BL;
using DotVVM.SampleWeb.BL.Queries;
using DotVVM.SampleWeb.BL.Queries.FirstLevel;
using DotVVM.SampleWeb.DAL;
using Microsoft.AspNetCore.Http;
using Riganti.Utils.Infrastructure.AutoMapper;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace DotVVM.SampleWeb.Web.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<Func<AppDbContext>>()
                    .Instance(() => new AppDbContextFactory().Create())
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkProvider>()
                    .ImplementedBy<EntityFrameworkUnitOfWorkProvider<AppDbContext>>()
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkRegistry>()
                    .UsingFactoryMethod(p => new AspNetCoreUnitOfWorkRegistry(p.Resolve<IHttpContextAccessor>(), new AsyncLocalUnitOfWorkRegistry()))
                    .LifestyleSingleton(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(AppQueryBase<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(AppFirstLevelQueryBase<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(IRepository<,>))
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient(),

                Component.For(typeof(IRepository<,>))
                    .ImplementedBy(typeof(EntityFrameworkRepository<,>))
                    .IsFallback()
                    .LifestyleTransient(),

                Component.For<IDateTimeProvider>()
                    .Instance(new UtcDateTimeProvider()),

                Component.For(typeof(IEntityDTOMapper<,>))
                    .ImplementedBy(typeof(EntityDTOMapper<,>))
                    .LifestyleSingleton()
            );
        }
    }
}