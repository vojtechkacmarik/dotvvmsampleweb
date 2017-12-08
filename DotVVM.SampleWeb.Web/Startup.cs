using System;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.MsDependencyInjection;
using DotVVM.Framework.Controls.DynamicData;
using DotVVM.Framework.Hosting;
using DotVVM.SampleWeb.BL;
using DotVVM.SampleWeb.DAL;
using DotVVM.SampleWeb.DAL.Entities;
using DotVVM.SampleWeb.Web.Installers;
using DotVVM.SampleWeb.Web.Settings;
using DotVVM.Tracing.ApplicationInsights.AspNetCore;
using DotVVM.Tracing.MiniProfiler.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling.Storage;

namespace DotVVM.SampleWeb.Web
{
    public class Startup
    {
        private static WindsorContainer container;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton(Configuration);
            services.AddSingleton((IConfigurationRoot)Configuration);

            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();

            services.AddDotVVM(options =>
            {
                options.AddDefaultTempStorages("Temp");
                options.AddMiniProfilerEventTracing();
                options.AddApplicationInsightsTracing();

                var dynamicDataConfig = new AppDynamicDataConfiguration();
                options.AddDynamicData(dynamicDataConfig);
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services
                .AddAuthentication(AuthenticationConstants.AUTHENTICATION_TYPE_NAME)
                .AddCookie(AuthenticationConstants.AUTHENTICATION_TYPE_NAME, options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Expiration = TimeSpan.FromDays(150);
                    options.LoginPath = new PathString("/Default3"); // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                    options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                    options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                    options.SlidingExpiration = true;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToReturnUrl = c => DotvvmAuthenticationHelper.ApplyRedirectResponse(c.HttpContext, c.RedirectUri),
                        OnRedirectToAccessDenied = c => DotvvmAuthenticationHelper.ApplyStatusCodeResponse(c.HttpContext, 403),
                        OnRedirectToLogin = c => DotvvmAuthenticationHelper.ApplyRedirectResponse(c.HttpContext, c.RedirectUri),
                        OnRedirectToLogout = c => DotvvmAuthenticationHelper.ApplyRedirectResponse(c.HttpContext, c.RedirectUri)
                    };
                });

            services.AddMemoryCache();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return WindsorRegistrationHelper.CreateServiceProvider(InitializeWindsor(), services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseMiniProfiler(options =>
            {
                options.RouteBasePath = "~/profiler";
                options.Storage = new MemoryCacheStorage(new MemoryCache(new MemoryCacheOptions()), TimeSpan.FromMinutes(60));
            });

            app.UseAuthentication();

            app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(env.WebRootPath)
            });
        }

        private static IWindsorContainer InitializeWindsor()
        {
            container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(FromAssembly.Containing<Startup>());

            AutoMapperInstaller.InitAutoMapper(container);

            return container;
        }

        internal static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}