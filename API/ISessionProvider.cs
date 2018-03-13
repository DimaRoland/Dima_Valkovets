using NHibernate;

namespace API
{
    public interface ISessionProvider
    {
        ISession OpenSession();
    }
}