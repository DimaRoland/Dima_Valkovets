using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public abstract class CachedRepository<T> : ICachedRepository
        where T : Entity<int>
    {
        #region fields

        private Task<IList<T>> _cache;

        #endregion fields

        #region properties

        protected Task<IList<T>> Cache => _cache ?? (_cache = LoadList());

        #endregion properties

        #region methods

        /// <summary>
        /// Returns the list of the <typeparamref name="T" /> as asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="Task" /> that will yield a list of the the <typeparamref name="T" />
        ///     objects.
        /// </returns>
        public Task<IList<T>> GetList()
        {
            return Cache;
        }

        /// <summary>
        /// Returns the <typeparamref name="T" /> as asynchronous operation.
        /// </summary>
        /// <returns>Returns a <see cref="Task" /> that will yield the <typeparamref name="T" />.</returns>
        public async Task<T> Get(int id)
        {
            return (await Cache).SingleOrDefault(it => it.Id == id);
        }

        /// <summary>
        /// Returns the list of the <typeparamref name="T" /> as asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="Task" /> that will yield a list of the the <typeparamref name="T" />
        ///     objects.
        /// </returns>
        public abstract Task<IList<T>> LoadList();

        public void InvalidateCache()
        {
            _cache = null;
        }

        #endregion methods
    }
}
