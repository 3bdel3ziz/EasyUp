using EasyUp.Core;
using EasyUp.IRepository;
using EasyUp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyUp.Api.Controllers
{
    public class ContentTypeController : ApiController
    {
        private IRepository<ContentType> _repository = null;

        public ContentTypeController()
        {
            this._repository = new Repository<ContentType>();
        }

        // GET api/values
        public string Get()
        {
            ContentType contentType = new ContentType();

            contentType.Name = "News22333";
            contentType.Code = "cd_news";
            contentType.Description = "";
            contentType.Icon = "";

            _repository.Insert(contentType);
            _repository.Save();

            return contentType.Name;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
