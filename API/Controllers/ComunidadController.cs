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
    public class ComunidadController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoComunidad _objCatalogoComunidad = new CatalogoComunidad();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/comunidad_consultar")]
        public object comunidad_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaComunidades = _objCatalogoComunidad.ConsultarComunidad().Where(c=>c.EstadoComunidad==true && c.Parroquia.EstadoParroquia == true && c.Parroquia.Canton.EstadoCanton == true && c.Parroquia.Canton.Provincia.EstadoProvincia==true).ToList();
                foreach (var item in _listaComunidades)
                {
                    item.IdComunidad = 0;
                    item.Parroquia.IdParroquia = 0;
                    item.Parroquia.Canton.IdCanton = 0;
                    item.Parroquia.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaComunidades;
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

        [HttpPost]
        [Route("api/comunidad_consultar")]
        public object comunidad_consultar(string _IdParroquiaEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                int _IdParroquiaDesEncriptado = Convert.ToInt32(_seguridad.DesEncriptar(_IdParroquiaEncriptado).ToString());

                var _listaComunidades = _objCatalogoComunidad.ConsultarComunidad().Where(c => c.EstadoComunidad == true && c.Parroquia.EstadoParroquia == true && c.Parroquia.Canton.EstadoCanton == true && c.Parroquia.Canton.Provincia.EstadoProvincia == true && _IdParroquiaDesEncriptado == c.Parroquia.IdParroquia ).ToList();
                foreach (var item in _listaComunidades)
                {
                    item.IdComunidad = 0;
                    item.Parroquia.IdParroquia = 0;
                    item.Parroquia.Canton.IdCanton = 0;
                    item.Parroquia.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaComunidades;
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
