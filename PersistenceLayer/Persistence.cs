using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelDataModel;
using DataModelNamespace;
using NHibernate;
using NHibernate.Dialect.Schema;
using NHibernate.Linq;


namespace PersistenceLayer
{

    public class ServerDataRepository : IServerDataRepository
    {

        private readonly ISession _session;

        public ServerDataRepository(ISession session)
        {
            _session = session;
        }   

        public IList<DataModel> Get()
        {
                var posts = _session.Query<DataModel>().ToList();
                return posts;

        }

        public DataViewModel GetID()
        {
            var datamodelid = _session.Query<DataModel>().Select(d => d.id).Max();
            var posts = _session.Query<DataModel>().Single(d => d.id == datamodelid);
            var result = Map(posts);
            return result;

        }


        public void Post(DataModel param)
        {
            if (param != null)
            _session.Save(param);
        }


        public DataModel GetdataModel(DataViewModel param)
        {
            var datamodel = Map(param);
            return datamodel;
        }

        public IList<DataViewModel> GetDataViewModel(IList<DataModel> param)
        {

            var dataviewmodel = Map(param);
            return dataviewmodel;
        }


        private DataModel Map(DataViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new DataModel(
                model.Title,
                model.Description,
                DateTime.Now.Date);
        }

        private DataViewModel Map(DataModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new DataViewModel
            {
            Title = model.Title,
            Description = model.Description,
            Posted = model.Posted
            };
        }

        private IList<DataViewModel> Map(IList<DataModel> model)
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
                    Posted = modelitem.Posted
                };

                dataViewModel.Add(dataViewModelitem);
            }

            return dataViewModel;

        }


    }

    public interface IServerDataRepository
    {
        IList<DataViewModel> GetDataViewModel(IList<DataModel> param);
        DataModel GetdataModel(DataViewModel param);

        DataViewModel GetID();
        IList<DataModel> Get();
        void Post(DataModel param);
    }
}
