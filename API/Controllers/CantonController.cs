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
    public class CantonController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoCanton _objCatalogoCanton = new CatalogoCanton();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/canton_consultar")]
        public object canton_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaCantones = _objCatalogoCanton.ConsultarCanton().Where(c => c.EstadoCanton == true && c.Provincia.EstadoProvincia == true).ToList(); ;
                foreach (var item in _listaCantones)
                {
                    item.IdCanton = 0;
                    item.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaCantones;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {

                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new
                {
                    respuesta = _respuesta,
                    http = _http
                };

            }
            return new { respuesta = _respuesta, http = _http };
        }
    }
}