using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.WebApi;

namespace API.InjectorConfigurator
{
    public static class SimpleInjectorConfigurator
    {
        #region properties

        public static Container Container { get; }

        #endregion properties

        #region constructors

        static SimpleInjectorConfigurator()
        {
            Container = new Container();
        }

        #endregion constructors

        #region methods

        public static void Configure()
        {
            Container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
            lifestyleSelector: () => Container.GetCurrentLifetimeScope() != null,
            trueLifestyle: new LifetimeScopeLifestyle(),
            falseLifestyle: new WebApiRequestLifestyle());
            Container.RegisterPackages();
        }

        public static void Verify()
        {
            Container.Verify();
        }

        #endregion methods
    }
}