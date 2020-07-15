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
    public class PeriodoController : ApiController
    {
        Seguridad _seguridad = new Seguridad();
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoPeriodo _objCatalogoPeriodo = new CatalogoPeriodo();
        [HttpPost]
        [Route("api/periodo_consultar")]
        public object periodo_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaPeriodos = _objCatalogoPeriodo.ConsultarPeriodo().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaPeriodos)
                {
                    item.IdPeriodo = 0;
                }
                _respuesta = _listaPeriodos;
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
