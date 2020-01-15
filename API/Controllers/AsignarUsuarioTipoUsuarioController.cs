using API.Models.Catalogos;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AsignarUsuarioTipoUsuarioController : ApiController
    {

        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarUsuarioTipoUsuario _objCatalogoAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();

        [HttpPost]
        [Route("api/asignarusuariotipousuario_consultar")]
        public object asignarusuariotipousuario_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                _respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Estado == true).ToList();
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }

            return new { respuesta = _respuesta, http = _http };
        }
    }
}
