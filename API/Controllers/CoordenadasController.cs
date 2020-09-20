using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class CoordenadasController : ApiController
    {
        // GET: Coordenadas
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoCoordenadas _objCatalogoCoordenadas = new CatalogoCoordenadas();
        Seguridad _seguridad = new Seguridad();

        [System.Web.Mvc.HttpPost]
        [System.Web.Http.Route("api/update/coordenadas")]
        public object coordenadas_insertar(Coordenadas coordenadas)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (coordenadas.latitud == null || string.IsNullOrEmpty(coordenadas.latitud))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la latitud";
                    return new { respuesta = _http.mensaje, http = _http.codigo };
                }
                if (coordenadas.longitud == null || string.IsNullOrEmpty(coordenadas.longitud))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la longitud";
                    return new { respuesta = _http.mensaje, http = _http.codigo };
                }
                if (Convert.ToString(coordenadas.id) == null)
                { 
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el id de la comunidad";
                    return new { respuesta = _http.mensaje, http = _http.codigo };
                }
                var idcomunidad= _seguridad.DesEncriptar(coordenadas.id);
                coordenadas.id = idcomunidad;
                var coordenada = _objCatalogoCoordenadas.ModificarCoordenadas(coordenadas);
                if (coordenada == 1)
                {
                    return new { respuesta = "Coordenadas actualizadas", http = 200 };
                }
                else {
                    return new { respuesta = "Error al actualizar las coordenadas", http = 406 };
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