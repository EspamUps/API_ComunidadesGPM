using API.Models.Catalogos;
using API.Models.Metodos;
using API.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PrefectoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoPrefecto _objCatalogoPrefecto = new CatalogoPrefecto();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/prefecto_consultar")]
        public object prefecto_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaPrefecto = _objCatalogoPrefecto.ConsultarPrefecto().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaPrefecto)
                {
                    item.IdPrefecto = 0;
                    item.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaPrefecto;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/prefecto_consultar")]
        public object prefecto_consultar(string _idPrefectoEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idPrefectoEncriptado == null || string.IsNullOrEmpty(_idPrefectoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del prefecto";
                }
                else
                {
                    int _idPrefecto = Convert.ToInt32(_seguridad.DesEncriptar(_idPrefectoEncriptado));
                    var _objPrefecto = _objCatalogoPrefecto.ConsultarPrefectoPorId(_idPrefecto).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objPrefecto == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el prefecto registrado.";
                    }
                    else
                    {
                        _objPrefecto.IdPrefecto = 0;
                        _objPrefecto.Provincia.IdProvincia = 0;
                        _respuesta = _objPrefecto;
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
    }
}
