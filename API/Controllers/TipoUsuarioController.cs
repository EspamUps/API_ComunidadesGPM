using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Controllers
{
    public class TipoUsuarioController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoTipoUsuarios _objCatalogoTipoUsuarios = new CatalogoTipoUsuarios();
        CatalogoTokens _objCatalogoTokens = new CatalogoTokens();
        Seguridad _seguridad = new Seguridad();
    
        [HttpPost]
        [Route("api/tipousuario_consultar")]
        public object tipousuario_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();

            try
            {
                _respuesta = _objCatalogoTipoUsuarios.ConsultarTipoUsuarios().Where(c=>c.Estado==true).ToList();
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " +ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }
            return new { respuesta = _respuesta, http = _http };
        }

    }
}
