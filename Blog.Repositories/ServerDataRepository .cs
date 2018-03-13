using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using NHibernate;
using NHibernate.Linq;
using System.Threading.Tasks;

namespace Blog.Repositories
{

    public class ServerDataRepository : IServerDataRepository
    {

        private readonly ISession _session;

        public ServerDataRepository(ISession session)
        {
            _session = session;
        }

        public async Task<IList<DataModel.DataModel>> GetList()
        {
            var posts = _session.Query<DataModel.DataModel>().ToList();
            return posts;

        }

        public DataViewModel GetId()
        {
            var datamodelid = _session.Query<DataModel.DataModel>().Select(d => d.id).Max();
            var posts = _session.Query<DataModel.DataModel>().Single(d => d.id == datamodelid);
            var result = Map(posts);
            return result;

        }

        public void Post(DataModel.DataModel param)
        {
            if (param != null)
                _session.Save(param);
        }

        public DataModel.DataModel GetdataModel(DataViewModel param)
        {
            var datamodel = Map(param);
            return datamodel;
        }

        public IList<DataViewModel> GetDataViewModel(IList<DataModel.DataModel> param)
        {

            var dataviewmodel = Map(param);
            return dataviewmodel;
        }


        private DataModel.DataModel Map(DataViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new DataModel.DataModel(
                model.Title,
                model.Description,
                DateTime.Now);
        }

        private DataViewModel Map(DataModel.DataModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new DataViewModel
            {
                Title = model.Title,
                Description = model.Description,
                Posted = model.Posted.ToString()
            };
        }

        private IList<DataViewModel> Map(IList<DataModel.DataModel> model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IList<DataViewModel> dataViewModel = new List<DataViewModel>();

            foreach (var modelitem in model)
            {

                var dataViewModelitem = new DataViewModel
                {
                    Title = modelitem.Title,
                    Description = modelitem.Description,
                    Posted = modelitem.Posted.ToString()
                };

                dataViewModel.Add(dataViewModelitem);
            }

            return dataViewModel;

        }


    }
}
