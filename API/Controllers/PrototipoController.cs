using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PrototipoController : ApiController
    {
        //[HttpGet]
        //[Route("api/prototipo1")]
        // GET: api/Prototipo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/Prototipo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prototipo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prototipo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prototipo/5
        public void Delete(int id)
        {
        }
    }
}
