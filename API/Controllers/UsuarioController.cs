using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using API.Conexion;
using API.Models.Entidades;
using API.Models.Catalogos;

namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        //ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        // GET: api/Usuario
        CatalogoUsuarios catUsuarios = new CatalogoUsuarios();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("api/ValidarCorreo")]
        public object ValidarCorreo(Usuario _item) {
            //string hola = "hola";
            //object respuesta = new { hola };
            return new { id = 1234 };
        }
        [HttpPost]
        [Route("api/Login")]
        public object Login(Usuario _item) {
            return new { id="dsdsd" };
        }

        [HttpGet]
        [Route("api/usuarios")]
        public object getusuarios()
        {
            return catUsuarios.Consultar();
            //return new { id = "dsdsd" };
        }

    }
}
