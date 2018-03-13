using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel;

namespace Blog.Repositories
{
    public class ServerDataCachedRepository
        : CachedRepository<DataModel.DataModel>, IServerDataRepository
    {
        #region fields

        private readonly IServerDataRepository _serverDataRepository;

        #endregion fields

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerDataCachedRepository" /> class.
        /// </summary>
        /// <param name="serverDataCachedRepository">
        ///     The instance of the <see cref="IServerDataRepository" /> that should be used.
        /// </param>
        public ServerDataCachedRepository(IServerDataRepository serverDataRepository)
        {
            _serverDataRepository = serverDataRepository;
        }

        public DataModel.DataModel GetdataModel(DataViewModel param)
        {
            throw new NotImplementedException();
        }

        public IList<DataViewModel> GetDataViewModel(IList<DataModel.DataModel> param)
        {
            throw new NotImplementedException();
        }

        public DataViewModel GetId()
        {
            throw new NotImplementedException();
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Returns the list of the <see cref="DataModel.DataModel" /> objects as asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="Task" /> that will yield a list of the the
        ///     <see cref="DataModel.DataModel" /> objects.
        /// </returns>
        public override Task<IList<DataModel.DataModel>> LoadList()
        {
            return _serverDataRepository.GetList();
        }

        public void Post(DataModel.DataModel param)
        {
            throw new NotImplementedException();
        }

        #endregion methods
    }
}
