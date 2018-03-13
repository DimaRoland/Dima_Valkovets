using API;
using API.InjectorConfigurator;
using Microsoft.Owin;
using Owin;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(Startup), "Configure")]
namespace API
{
    public class Startup
    {
        public static void Configure(IAppBuilder app)
        {
            SimpleInjectorConfigurator.Configure();
            SimpleInjectorConfigurator.Verify();

            var dependencyResolver = new SimpleInjectorWebApiDependencyResolver(
                SimpleInjectorConfigurator.Container);

            WebApiConfigurator.Configure();
            WebApiConfigurator.SetDependencyResolver(dependencyResolver);
            WebApiConfigurator.EnsureInitialized();

            app.UseWebApi(WebApiConfigurator.Configuration);
        }
    }

}

