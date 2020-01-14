using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Entidades;

namespace API.Controllers
{
    public class PersonaController : ApiController
    {
        // GET: api/Persona
        [HttpPost]
        [Route("api/persona_consultar")]
        public object  persona_consultar(Persona _item)
        {
            return new object();
        }
        
    }
}
