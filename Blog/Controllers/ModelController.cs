using DataModelNamespace;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ModelController : ApiController
    {
        private ServerDataRepository obj = new ServerDataRepository();

        public IHttpActionResult Get()
        {
            var _model = obj.Get();
            return Json(_model);
        }
    }
}