using System;
using NHibernate;
using PersistenceLayer;

namespace API
{
    public class SessionProvider : ISessionProvider
    {
        #region fields

        private readonly Lazy<ISessionFactory> _sessionFactory;

        #endregion fields

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProvider" /> class.
        /// </summary>
        /// <param name="databaseConfigurator">The database configurator.</param>
        public SessionProvider(IDatabaseConfigurator databaseConfigurator)
        {
            _sessionFactory = new Lazy<ISessionFactory>(databaseConfigurator.CreateSessionFactory, true);
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Creates the <see cref="ISession" /> object.
        /// </summary>
        /// <returns>Created session.</returns>
        public ISession OpenSession()
        {
            return _sessionFactory.Value.OpenSession();
        }

        #endregion methods
    }
}