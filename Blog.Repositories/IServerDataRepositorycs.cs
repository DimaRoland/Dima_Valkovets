using System.Collections.Generic;
using DataModel;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public interface IServerDataRepository
    {
        IList<DataViewModel> GetDataViewModel(IList<DataModel.DataModel> param);

        DataModel.DataModel GetdataModel(DataViewModel param);

        DataViewModel GetId();

        Task<IList<DataModel.DataModel>> GetList();

        void Post(DataModel.DataModel param);
    }
}
