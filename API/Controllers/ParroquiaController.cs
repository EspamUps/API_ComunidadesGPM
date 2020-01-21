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
    public class ParroquiaController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoParroquia _objCatalogoParroquia = new CatalogoParroquia();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/parroquia_consultar")]
        public object parroquia_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaParroquias = _objCatalogoParroquia.ConsultarParroquia().Where(c => c.EstadoParroquia == true && c.Canton.EstadoCanton == true && c.Canton.Provincia.EstadoProvincia == true).ToList();
                foreach (var item in _listaParroquias)
                {
                    item.IdParroquia = 0;
                    item.Canton.IdCanton = 0;
                    item.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaParroquias;
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
