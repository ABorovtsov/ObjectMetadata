using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using ObjectMetadata.Core;
using ObjectMetadata.Samples.Common;

namespace ObjectMetadata.Samples.AspNet.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        // POST: api/Default
        public IHttpActionResult Post([ModelBinder] MyModel model)
        {
            string message = string.Empty;
            if (model is IMetadataAware ma)
            {
                message += $"*** The model has metadata. ";
            }

            message += JsonConvert.SerializeObject(model);

            return Ok(message);
        }

        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
