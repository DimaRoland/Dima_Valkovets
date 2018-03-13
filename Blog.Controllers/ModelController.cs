using System.Web.Http;
using Blog.Repositories;
using DataModel;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class ModelController : ApiController
    {
        private readonly IServerDataRepository _iServerDataRepository;

        public ModelController(IServerDataRepository serverDataRepository)
        {
            _iServerDataRepository = serverDataRepository;
        }

        [HttpGet, Route("api/Model")]
        public async Task<IHttpActionResult> Get()
        {
            var model = await _iServerDataRepository.GetList();
            var result = _iServerDataRepository.GetDataViewModel(model);

            return Ok(result);
        }

        [HttpGet, Route("api/Model/GetId")]
        public IHttpActionResult GetId()
        {
            var dataModelId = _iServerDataRepository.GetId();
            return Ok(dataModelId);
        }

        [HttpPost, Route("api/Model/Post")]
        public IHttpActionResult Post(DataViewModel param)
        {
            var datamodel = _iServerDataRepository.GetdataModel(param);
            _iServerDataRepository.Post(datamodel);
            return Ok();
        }
    }

}
