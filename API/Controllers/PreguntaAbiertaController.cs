using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Metodos;
using API.Models.Entidades;

namespace API.Controllers
{
    public class PreguntaAbiertaController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoPregunta _objCatalogoPregunta = new CatalogoPregunta();
        CatalogoPreguntaAbierta _objCatalogoPreguntaAbierta = new CatalogoPreguntaAbierta();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/preguntaabierta_insertar")]
        public object preguntaabierta_insertar(PreguntaAbierta _objPreguntaAbierta)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
    }
}
