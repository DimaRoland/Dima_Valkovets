using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace PersistenceLayer
{
    public class NHibernateHelper : IDatabaseConfigurator
    {
        public  ISessionFactory CreateSessionFactory()
        {
            var config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("MyBlog")))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModelDataMap>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();

            return config;
        }
    }
    public interface IDatabaseConfigurator
    {
        ISessionFactory CreateSessionFactory();
    }
}
