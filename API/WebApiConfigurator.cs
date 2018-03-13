using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Newtonsoft.Json;

namespace API
{
    public static class WebApiConfigurator
    {
        #region properties

        /// <summary>
        /// Gets a configuration of HTTP Server.
        /// </summary>
        public static HttpConfiguration Configuration { get; }

        #endregion properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpConfiguration" /> class.
        /// </summary>
        static WebApiConfigurator()
        {
            Configuration = new HttpConfiguration();
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Configures the Web Api HTTP server instance.
        /// </summary>
        public static void Configure()
        {

            Configuration.MapHttpAttributeRoutes();

            var serializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            var jsonMediaTypeFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = serializerSettings
            };

            Configuration.Formatters.Clear();
            Configuration.Formatters.Add(jsonMediaTypeFormatter);
            Configuration.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());

        }

        /// <summary>
        /// Sets the dependency resolver to <see cref="P:WebApiConfigurator.Configuration" />.
        /// </summary>
        /// <param name="resolver">The dependency resolver that should be set.</param>
        public static void SetDependencyResolver(IDependencyResolver resolver)
        {
            Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Invokes the initializer hook. It is considered immutable from this point forward. It is safe to call
        /// this multiple times.
        /// </summary>
        public static void EnsureInitialized()
        {
            Configuration.EnsureInitialized();
        }

        #endregion methods
    }
}