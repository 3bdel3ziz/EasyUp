using EasyUp.Core;
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
        // GET api/values
        public string Get()
        {
            ContentType contentType = new ContentType();

            contentType.Name = "News";
            contentType.Code = "cd_news";
            contentType.Description = "";
            contentType.Icon = "";

            EasyUpDbContext dbContext = new EasyUpDbContext();

            dbContext.ContentTypes.Add(contentType);
            dbContext.SaveChanges();

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
