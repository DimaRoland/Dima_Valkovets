using Blog.Repositories;
using PersistenceLayer;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace API.SimpleInjectorPackages
{
    public class SimpleInjectorPackagescs: IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ISessionProvider, SessionProvider>();
            container.Register<IDatabaseConfigurator, NHibernateHelper>();
            container.Register<IServerDataRepository, ServerDataRepository>();
            container.Register(
                () => container.GetInstance<ISessionProvider>().OpenSession(),
                Lifestyle.Scoped);

            container.RegisterDecorator<IServerDataRepository, ServerDataCachedRepository>(Lifestyle.Singleton);
        }
    }
}